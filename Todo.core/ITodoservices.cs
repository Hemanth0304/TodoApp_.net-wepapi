using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.core
{
   public interface ITodoservices
    {
        List<Todos> GetTodos();

        Todos AddTodo(Todos todo);

        void DeleteTask(string id);

        Todos UpdateTask(Todos todo);
    }
}
