using ShopSol.Infraestructura.Base;
using ShopSol.Infraestructura.Notification.Interfaces;

namespace ShopSol.Infraestructura.Notification.Service
{
    public class EmailServer : INotificationService<EmailServer>
    {
        public Task<NotificationResult>Send(EmailServer model)
        {
            throw new NotImplementedException();
        }
    }
}
