using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.Contracts.Interfaces
{
    public interface IRequest
    {
        public Guid RequestId { get; set; }
    }
}
