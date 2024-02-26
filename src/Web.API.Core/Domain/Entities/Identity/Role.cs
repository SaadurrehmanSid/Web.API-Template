using Microsoft.AspNetCore.Identity;
using Web.API.Core.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.API.Core.Domain.Entities.Identity;

[Table("Role")]
public class Role : IdentityRole<long>
{
  public Role()
  {
  }

  public Role(string name) : base(name)
  {
  }
  public Role(string name,long clientGroupId) : base(name)
  {
    ClientGroupId = clientGroupId;
  }
  [MaxLength(256)]
  public string DisplayName { get; set; } = "";
  public long ClientGroupId { get; set; }
  public bool IsSystem { get; set; }
}
