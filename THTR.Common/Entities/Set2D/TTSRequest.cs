using System;

namespace THTR.Common.Entities.Set2D;

public class TTSRequest
{
    public Guid id { get; set; }
    public string? text { get; set; }
    public string? voice_id { get; set; }
    public DateTime create_date { get; set; }
    public DateTime update_date { get; set; }
}
