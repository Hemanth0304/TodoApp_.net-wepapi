using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Todos> _todos;
        public DbClient(IOptions<TodoDBConfig> todoDbConfig)
        {
            var client = new MongoClient(todoDbConfig.Value.Connection_String);
            var database = client.GetDatabase(todoDbConfig.Value.Database_Name);
            _todos = database.GetCollection<Todos>(todoDbConfig.Value.Collection_Name);
        }
        public IMongoCollection<Todos> GetTodoCollection() => _todos;
      
    }
}
