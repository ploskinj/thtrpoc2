using MessagePack;
using System.Collections.Concurrent;

namespace THTR.Client.Web.THTR.POC
{
    public class POCGameState
    {
        ConcurrentDictionary<string, PlayerState> players = new ConcurrentDictionary<string, PlayerState>();
    }

    [MessagePackObject]
    public class PocPlayerClientDrawState
    {
        [Key(0)]
        public int player_id { get; set; }
        [Key(1)]
        public int map_x { get; set; }
        [Key(2)]
        public int map_y { get; set; }
        [Key(3)]
        public int velocity_x { get; set; }
        [Key(4)]
        public int velocity_y { get; set; }
        [Key(5)]
        public int state_elapsed_ms { get; set; }
        [Key(6)]
        public PLAYERSTATES state { get; set; }
        [Key(7)]
        public DIRECTIONS direction { get; set; }
    }


    

    public class PlayerState
    {
        public string connection_id { get; set; } = string.Empty;
        public bool up { get; set; } = false;
        public bool down { get; set; } = false;
        public bool left { get; set; } = false;
        public bool right { get; set; } = false;
        public bool attack { get; set; } = false;
    }


    public enum PLAYERSTATES
    {
        IDLE1 = 0, 
        IDLE2 = 1, 
        WALK = 2, 
        ATTACK = 3        
    }

    public enum DIRECTIONS
    {
        NORTH = 0, 
        EAST = 1, 
        SOUTH = 2, 
        WEST = 3
    }
}
