using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public class Notification
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public string NotificationType { get; set; }
        public string Message { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime DeliveredAt { get; set; }
    }
}
