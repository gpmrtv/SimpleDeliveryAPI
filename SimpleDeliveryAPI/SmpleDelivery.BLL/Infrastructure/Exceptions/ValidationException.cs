using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.BLL.Infrastructure.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            :base(message)
        {

        }
    }
}
