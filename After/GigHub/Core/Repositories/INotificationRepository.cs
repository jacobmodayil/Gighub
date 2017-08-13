using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface INotificationRepository
    {
        List<Notification> GetUserNotificationsWithArtist(string userId);
        List<UserNotification> GetAllUserNotifications(string userId);
    }
}