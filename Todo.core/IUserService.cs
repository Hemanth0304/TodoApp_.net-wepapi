using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.core
{
    public interface IUserService
    {
       List<Users> Userss { get; }

        List<Users> GetUsers();

        Users AddUsers(Users user);

    }
}