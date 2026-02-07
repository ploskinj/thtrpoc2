using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using THTR.Client.Web.Hubs;

namespace THTR.Client.Web.THTR.POC;

// house manager is what runs the connect/disconnect, list of players, 
public class PocDirector
{
    private readonly IHubContext<POCHub> _hub_context;
    private readonly ConcurrentDictionary<string, PocPlayer> _players;
    private Timer? _tick_timer;

    public PocDirector(IHubContext<POCHub> hub_context)
    {
        _hub_context = hub_context;
        _players = new ConcurrentDictionary<string, PocPlayer>();
        start_tick();
    }

    private void start_tick()
    {
        _tick_timer = new Timer(async _ => await tick(), null, TimeSpan.Zero, TimeSpan.FromMilliseconds(50));
    }

    public async Task tick()
    {
        var game_state = new
        {
            player_count = _players.Count,
            timestamp = DateTime.UtcNow,
            players = _players.Values
        };

        await _hub_context.Clients.All.SendAsync("receive_game_state", game_state);
    }

    public void enter(string connection_id, PocPlayer player)
    {
        _players.TryAdd(connection_id, player);
    }

    public void exit(string connection_id)
    {
        _players.TryRemove(connection_id, out _);
    }
}
