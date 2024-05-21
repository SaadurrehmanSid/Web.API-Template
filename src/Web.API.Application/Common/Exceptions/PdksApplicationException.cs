using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Application.Common.Exceptions
{
    public class PdksApplicationException : Exception
    {
        private readonly HttpStatusCode statusCode;
        protected PdksApplicationException(SerializationInfo info, StreamingContext context)
     : base(info, context)
        {
            // De serialize additional members if needed
        }

        public PdksApplicationException(HttpStatusCode statusCode, string message, Exception ex)
            : base(message, ex)
        {
            this.statusCode = statusCode;
        }

        public PdksApplicationException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            this.statusCode = statusCode;
        }

        public PdksApplicationException(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
        }

        public HttpStatusCode StatusCode
        {
            get { return statusCode; }
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Serialize the base class members
            base.GetObjectData(info, context);

            // Serialize additional members if needed
        }
    }
}
