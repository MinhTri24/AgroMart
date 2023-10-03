using Microsoft.AspNetCore.Identity;

namespace AgroMart.Models;

public class ApplicationUser : IdentityUser
{
    [PersonalData]
    public string FullName { get; set; }
    [PersonalData]
    public string Address { get; set; }
    [PersonalData]
    public string ImageUrl { get; set; }
}