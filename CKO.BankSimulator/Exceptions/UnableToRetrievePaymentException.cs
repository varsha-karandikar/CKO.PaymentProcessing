using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Exceptions
{
    public class UnableToRetrievePaymentException : Exception
    {
        public UnableToRetrievePaymentException()
        {

        }

        public UnableToRetrievePaymentException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public UnableToRetrievePaymentException(string message) : base(message)
        {



        }
    }
}
