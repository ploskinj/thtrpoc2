using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using THTR.Client.Web.Hubs;
namespace THTR.Client.Web.THTR.POC;

public class PocDirector
{    
    private readonly ConcurrentDictionary<string, PlayerState> _players = new ConcurrentDictionary<string, PlayerState>();
    private readonly ConcurrentDictionary<string, PocPlayerClientDrawState> _player_client_draw_states
                                                    = new ConcurrentDictionary<string, PocPlayerClientDrawState>();
    private Timer? _tick_timer;
    public PocDirector()
    {       
    }

    public void enter(string connection_id)
    {
        PocPlayerClientDrawState draw_state = new PocPlayerClientDrawState();
        PlayerState player_state = new PlayerState();
        _players.TryAdd(connection_id, player_state);
        _player_client_draw_states.TryAdd(connection_id, draw_state);
    }
    public void exit(string connection_id)
    {
        _players.TryRemove(connection_id, out _);
        _player_client_draw_states.TryRemove(connection_id, out _);
    }

    public void up_down(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.up = true;
        }
    }

    public void up_up(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.up = false;
        }
    }

    public void down_down(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.down = true;
        }
    }

    public void down_up(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.down = false;
        }
    }

    public void left_down(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.left = true;
        }
    }

    public void left_up(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.left = false;
        }
    }

    public void right_down(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.right = true;
        }
    }

    public void right_up(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.right = false;
        }
    }

    public void attack_down(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.attack = true;
        }
    }

    public void attack_up(string connection_id)
    {
        if (_players.TryGetValue(connection_id, out var player))
        {
            player.attack = false;
        }
    }
}