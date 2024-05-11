using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPIncInvest.Application.Notifications.UserNotification
{
    public class UserCreatedNotification : INotification
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
