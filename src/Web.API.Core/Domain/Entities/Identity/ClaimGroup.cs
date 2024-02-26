using System.ComponentModel;

namespace Web.API.Core.Domain.Entities.Identity;

public class ClaimGroup : BaseEntity<long>
{
  public string? Name { get; set; }
  [DefaultValue(true)]
  public bool IsDisplay { get; set; }
  public virtual List<ApplicationClaim>? ApplicationClaims { get; set; }
  public int Sequence { get; set; }
}
