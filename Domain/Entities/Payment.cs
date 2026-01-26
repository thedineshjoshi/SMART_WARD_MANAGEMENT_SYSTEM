using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public Guid ReferenceId { get; set; }
        public string ReferenceType { get; set; }
        public int Amount { get; set; }
        public string PaymentGateway { get; set; }
        public Guid TransactionId { get; set; }
        public bool PaymentStatus { get; set; }
        public DateTime PaidAt { get; set; }

    }
}
