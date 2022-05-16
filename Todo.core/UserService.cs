using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.core
{
   public class UserService : IUserService
    {
        private readonly IMongoCollection<Users> _Users;
        public UserService(IDbClient dbClient)
        {
            _Users = dbClient.GetUserCollection();
        }

      
        public Users AddUsers(Users user)
        {
            _Users.InsertOne(user);
            return user;
        }



        public List<Users> GetUsers() => _Users.Find(user => true).ToList();

    }
}
