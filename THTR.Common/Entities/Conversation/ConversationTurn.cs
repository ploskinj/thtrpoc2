using System;

namespace THTR.Common.Entities.Conversation;

public class ConversationTurn
{
    public Guid id { get; set; }    
    public Guid conversant_id { get; set; }
    public int conversant_type { get; set; }    
    public int turn_order { get; set; }
    public DateTime create_date { get; set; }
    public DateTime update_date { get; set; }
}
