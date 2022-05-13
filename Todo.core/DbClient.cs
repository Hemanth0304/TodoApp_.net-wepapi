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
        private readonly IMongoCollection<Users> _users;
        public DbClient(IOptions<TodoDBConfig> todoDbConfig)
        {
            var client = new MongoClient(todoDbConfig.Value.Connection_String);
            var database = client.GetDatabase(todoDbConfig.Value.Database_Name);
            _todos = database.GetCollection<Todos>(todoDbConfig.Value.Collection_Name);

            var client2 = new MongoClient(todoDbConfig.Value.Connection_String);
            var database2 = client2.GetDatabase(todoDbConfig.Value.Database_Name);
            _users = database2.GetCollection<Users>(todoDbConfig.Value.Collection_Name2);



        }
        public IMongoCollection<Todos> GetTodoCollection() => _todos;



        public IMongoCollection<Users> GetUserCollection() => _users;
       
    }
}
