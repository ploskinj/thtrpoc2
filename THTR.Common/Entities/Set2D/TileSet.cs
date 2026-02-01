using System;

namespace THTR.Common.Entities.Set2D;

public class TileSet
{
    public Guid id { get; set; }
    public string? name { get; set; }
    public string? sprite_sheet_path { get; set; }
    public DateTime create_date { get; set; }
    public DateTime update_date { get; set; }
}

public class Tile
{
    public Guid id { get; set; }
    public Guid tile_set_id { get; set; }
    public string? name { get; set; }
    public int ssx { get; set; }
    public int ssy { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public bool collidable { get; set; }
    public bool visible { get; set; }
    public DateTime create_date { get; set; }
    public DateTime update_date { get; set; }
}
