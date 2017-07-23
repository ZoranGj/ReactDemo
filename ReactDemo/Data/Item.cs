using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Item
    {
        public ObjectId Id { get; set; }
        [BsonElement("ItemId")]
        public int ItemId { get; set; }
        [BsonElement("ItemName")]
        public string ItemName { get; set; }
    }
}
