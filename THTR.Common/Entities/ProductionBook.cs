using System;

namespace THTR.Common.Entities;

public class ProductionBook
{
    public Guid id { get; set; }
    public string? name { get; set; }
    public Guid set_2d_id { get; set; }
    public DateTime create_date { get; set; }
    public DateTime update_date { get; set; }
}
