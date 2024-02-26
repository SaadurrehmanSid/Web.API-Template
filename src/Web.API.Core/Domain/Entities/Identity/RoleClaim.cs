﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Web.API.Core.Domain.Entities.Identity;

//old name : Assigned Role Claim
[Table("RoleClaim")]
public class RoleClaim : IdentityRoleClaim<long>
{
  //public long Id { get; set; }
  //[ForeignKey("Role")]
  //public long RoleId { get; set; }

  public RoleClaim()
  {
  }

  //public virtual Role Role { get; set; }

  [ForeignKey("ApplicationClaim")]
  public long ApplicationClaimId { get; set; }
  public virtual ApplicationClaim? ApplicationClaim { get; set; }
  public bool IsAssigned { get; set; }
}
