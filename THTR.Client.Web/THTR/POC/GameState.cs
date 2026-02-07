using MessagePack;

namespace THTR.Client.Web.THTR.POC
{
    public class POCGameState
    {
        List<PocPlayer> players = new List<PocPlayer>();
    }

    [MessagePackObject]
    public class PocPlayer
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
