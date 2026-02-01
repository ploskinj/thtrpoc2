using System;

namespace THTR.Common.Entities.Set2D;

public class SetElement2D
{
    public Guid id { get; set; }
    public Guid set_2d_id { get; set; }
    public string? name { get; set; }
    public int map_x { get; set; }
    public int map_y { get; set; }
    public Guid tile_set_id { get; set; }
    public Guid tile_id { get; set; }
    public DateTime create_date { get; set; }
    public DateTime update_date { get; set; }
}
