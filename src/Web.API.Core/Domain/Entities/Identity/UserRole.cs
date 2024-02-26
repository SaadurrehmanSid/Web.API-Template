using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Web.API.Core.Domain.Entities.Identity;

[Table("UserRole")]
public class UserRole : IdentityUserRole<long>
{
  //public UserRole()
  //{
  //  Role = new Role();
  //}

  //[ForeignKey("RoleId")]
  //public Role Role { get; set; } 
}
