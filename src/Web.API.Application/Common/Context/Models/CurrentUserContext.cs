using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Application.Common.Context.Models
{
    public class CurrentUserContext
    {
        public CurrentUserContext()
        {
            NotMappedRoles = new List<string>();
        }

        public long Id { get; set; }
        public long ClientGroupId { get; set; }
        public long SubscriptionTypeId { get; set; }
        public long SubscriptionPriceId { get; set; }
        public long ClientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }

        public bool VerifiedEmail { get; set; }

        //user type customer/administrator
        public int UserTypeId { get; set; }
        public virtual List<string> NotMappedRoles { get; set; }

    }
}
