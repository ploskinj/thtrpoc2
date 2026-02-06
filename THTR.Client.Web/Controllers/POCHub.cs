using Microsoft.AspNetCore.SignalR;

namespace THTR.Client.Web.Hubs
{
    public class POCHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("receive_tick", DateTime.UtcNow);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task send_tick_to_all()
        {
            await Clients.All.SendAsync("receive_tick", DateTime.UtcNow);
        }

        public async Task send_tick_to_caller()
        {
            await Clients.Caller.SendAsync("receive_tick", DateTime.UtcNow);
        }
    }

}
