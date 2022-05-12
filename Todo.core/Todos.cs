using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.core
{
   public class Todos
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        public string title { get; set; }

        public string decsription { get; set; }

        public bool Status { get; set; }

        public string Name { get; set; }
        [BsonElement("Task")]
        public string[]? Task { get; set; }

        public DateTime today { get; set; }
    }
}
