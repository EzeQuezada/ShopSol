

using ShopSol.Infraestructura.Base;
using ShopSol.Infraestructura.Notification.Interfaces;

namespace ShopSol.Infraestructura.Notification.Service
{
    public class SmsService : INotificationService<SmsService>
    {
        public Task<NotificationResult> Send(SmsService model)
        {
            throw new NotImplementedException();
        }
    }
}
