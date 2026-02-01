using System;

namespace THTR.Common.Entities.Conversation;

public class Conversation
{
    public Guid id { get; set; }
    public string title { get; set; }
    public string summary { get; set; }
    public DateTime create_date { get; set; }
    public DateTime update_date { get; set; }
}
