using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interactive.Model.Exceptions
{
    public class DebitException : Exception, ISerializable
    {
        public DebitException()
        {
        }

        public DebitException(string message) : base(message)
        {
        }

        public DebitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DebitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
