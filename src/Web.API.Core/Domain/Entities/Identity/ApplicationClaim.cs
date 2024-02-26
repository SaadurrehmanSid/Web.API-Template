using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.API.Core.Domain.Interfaces;

namespace Web.API.Core.Domain.Entities.Identity;


public class ApplicationClaim : ISoftDeleteEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public long Id { get; set; }
  public string? ClaimCode { get; set; }
  public string? ClaimValue { get; set; }
  public bool IsDeleted { get; set; }

  [DefaultValue(true)]
  public bool IsDisplay { get; set; }

  [ForeignKey("ClaimGroup")]
  public long ClaimGroupId { get; set; }
  public virtual ClaimGroup? ClaimGroup { get; set; }
}
