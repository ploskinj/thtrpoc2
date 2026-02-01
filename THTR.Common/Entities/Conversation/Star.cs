using System;
using System.Text.Json.Serialization;

namespace THTR.Common.Entities.Conversation;

public class Star
{
    public Guid id { get; set; }    
    public string handle { get; set; }    
    public string first_name { get; set; }    
    public string last_name { get; set; }
    public string? backstory { get; set; }
    public DateTime create_date { get; set; }
    public DateTime update_date { get; set; }
    public int avatar_id { get; set; }     
}
