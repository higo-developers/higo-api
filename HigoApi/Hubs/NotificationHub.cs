using Microsoft.AspNetCore.SignalR;

namespace HigoApi.Hubs
{
    public class NotificationHub : Hub
    {
        public string Activated()
        {
            return string.Empty;
        }
    }
}
