using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPIncInvest.Application.Notifications.UserNotification;

namespace XPIncInvest.Application.EventHandlers
{
    public class LogEventHandler : INotificationHandler<UserCreatedNotification>
    {
        public Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO '{notification.UserId} - {notification.Name}'");
            });
        }

    }
}
