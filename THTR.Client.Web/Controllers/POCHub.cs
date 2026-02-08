using Microsoft.AspNetCore.SignalR;
using THTR.Client.Web.THTR.POC;
namespace THTR.Client.Web.Hubs
{
    public class POCHub : Hub
    {
        private static readonly PocDirector _director = new PocDirector();

        public override async Task OnConnectedAsync()
        {
            _director.enter(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _director.exit(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        // ----------   client input
        public async Task client_up_down()
        {
            var connection_id = Context.ConnectionId;
            _director.up_down(connection_id);
            await Clients.All.SendAsync("client_up_down", connection_id, DateTime.UtcNow);
        }

        public async Task client_up_up()
        {
            var connection_id = Context.ConnectionId;
            _director.up_up(connection_id);
            await Clients.All.SendAsync("client_up_up", connection_id, DateTime.UtcNow);
        }

        public async Task client_down_down()
        {
            var connection_id = Context.ConnectionId;
            _director.down_down(connection_id);
            await Clients.All.SendAsync("client_down_down", connection_id, DateTime.UtcNow);
        }

        public async Task client_down_up()
        {
            var connection_id = Context.ConnectionId;
            _director.down_up(connection_id);
            await Clients.All.SendAsync("client_down_up", connection_id, DateTime.UtcNow);
        }

        public async Task client_left_down()
        {
            var connection_id = Context.ConnectionId;
            _director.left_down(connection_id);
            await Clients.All.SendAsync("client_left_down", connection_id, DateTime.UtcNow);
        }

        public async Task client_left_up()
        {
            var connection_id = Context.ConnectionId;
            _director.left_up(connection_id);
            await Clients.All.SendAsync("client_left_up", connection_id, DateTime.UtcNow);
        }

        public async Task client_right_down()
        {
            var connection_id = Context.ConnectionId;
            _director.right_down(connection_id);
            await Clients.All.SendAsync("client_right_down", connection_id, DateTime.UtcNow);
        }

        public async Task client_right_up()
        {
            var connection_id = Context.ConnectionId;
            _director.right_up(connection_id);
            await Clients.All.SendAsync("client_right_up", connection_id, DateTime.UtcNow);
        }

        public async Task client_attack_down()
        {
            var connection_id = Context.ConnectionId;
            _director.attack_down(connection_id);
            await Clients.All.SendAsync("client_attack_down", connection_id, DateTime.UtcNow);
        }

        public async Task client_attack_up()
        {
            var connection_id = Context.ConnectionId;
            _director.attack_up(connection_id);
            await Clients.All.SendAsync("client_attack_up", connection_id, DateTime.UtcNow);
        }
    }
}