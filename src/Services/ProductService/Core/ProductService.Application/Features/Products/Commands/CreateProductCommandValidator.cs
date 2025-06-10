using FluentValidation;

namespace ProductService.Application.Features.Products.Commands;

public class CreateProductCommandValidator  : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(2, 20).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");

        RuleFor(p => p.Rate)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .LessThan(500);
    }
}
