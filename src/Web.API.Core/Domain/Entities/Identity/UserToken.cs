using Microsoft.AspNetCore.Identity;

namespace Web.API.Core.Domain.Entities.Identity;

public class UserToken : IdentityUserToken<long>
{
  public DateTimeOffset? TokenExpiryTime { get; set; }
}
