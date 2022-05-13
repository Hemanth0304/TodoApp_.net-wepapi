using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.core
{
    public interface IDbClient
    {
        IMongoCollection<Todos> GetTodoCollection();
        IMongoCollection<Users> GetUserCollection();
    }
}
