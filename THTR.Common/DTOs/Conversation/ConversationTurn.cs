using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using THTR.Common;

namespace THTR.Common.DTOs.Conversation
{
    public class ConversationTurn
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }

        [JsonPropertyName("utterance")]
        public string utterance { get; set; }

        [JsonPropertyName("conversant_id")]
        public Guid conversant_id { get; set; }

        [JsonPropertyName("conversant_type")]
        public ConversantTypes conversant_type { get; set; }
        [JsonPropertyName("turn_order")]
        public int turn_order {  get; set; }
    }
}
