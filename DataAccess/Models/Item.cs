using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public int ListId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int Priority { get; set; }
        public string Tags { get; set; } = string.Empty;
        public List<string> CardTags { get; set; } = new List<string>();
        public string RelatedTo { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
}
