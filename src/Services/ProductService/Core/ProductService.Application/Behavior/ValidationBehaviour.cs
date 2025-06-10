using FluentValidation;
using MediatR;

namespace ProductService.Application.Behavior;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // preprocessing logics like logging, caching, validation, etc. can be added here
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var result = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = result
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
        }   
        
        // next
        var response = await next(cancellationToken);

        // postprocessing logics like response transformation, logging, etc. can be added here
        return response;
    }
}
