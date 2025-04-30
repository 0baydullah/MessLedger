using Microsoft.AspNetCore.Identity;

namespace ML.Repository.Entities;

public class User : IdentityUser
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public bool IsActive{get;set;}
}