using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Exceptions
{
    public class UnableToCreatePaymentException : Exception
    {
        public UnableToCreatePaymentException()
        {

        }

        public UnableToCreatePaymentException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public UnableToCreatePaymentException(string message) : base(message)
        {



        }
    }
}
