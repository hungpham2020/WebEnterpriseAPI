using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebEnterpriseAPI.Model
{
    public class CustomUser: IdentityUser
    {
        public string? FullName { get; set; }
    }
}
