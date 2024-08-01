

using ShopSol.Infraestructura.Base;

namespace ShopSol.Infraestructura.Notification.Interfaces
{
    public interface INotificationService<TModel>where TModel : class
    {
        public Task<NotificationResult> Send(TModel model);
    }
}
