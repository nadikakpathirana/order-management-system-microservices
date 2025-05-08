using Microsoft.AspNetCore.Identity;

namespace UserService.Model.IdentityExtendModels;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
