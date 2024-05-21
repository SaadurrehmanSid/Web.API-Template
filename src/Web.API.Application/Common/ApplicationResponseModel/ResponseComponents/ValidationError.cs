using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Application.Common.ApplicationResponseModel.ResponseComponents
{
    public class ValidationError
    {
        private string name = string.Empty;
        public required string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name)) return name;

                return char.ToLowerInvariant(name[0]) + name.Substring(1);
            }
            set
            {
                name = value;
            }
        }
        public required string Message { get; set; }
    }
}
