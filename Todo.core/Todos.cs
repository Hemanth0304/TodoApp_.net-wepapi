using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
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

        public string IEmpId { get; set; }

        public string title { get; set; }

        public string decsription { get; set; }

        public bool Status { get; set; }

        public string Name { get; set; }

//        [BsonElement("Task")]
//#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
//        public Dictionary<string, object>[] Task { get; set; }
//#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        public DateTime today { get; set; }
    }
}
