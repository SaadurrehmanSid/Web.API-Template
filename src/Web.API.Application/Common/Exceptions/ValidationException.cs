using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        protected ValidationException(SerializationInfo info, StreamingContext context)
             : base(info, context)
        {
            Errors = new Dictionary<string, string[]>();
        }
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }



        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Serialize the base class members
            base.GetObjectData(info, context);

            // Serialize additional members if needed
        }

        public IDictionary<string, string[]> Errors { get; }
    }

}
