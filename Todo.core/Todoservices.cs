using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.core
{
    public class Todoservices : ITodoservices
    {
        private readonly IMongoCollection<Todos> _todos;

        public Todoservices(IDbClient dbClient)
         {
            _todos = dbClient.GetTodoCollection();
        }

        public Todos AddTodo(Todos todo)
        {
            _todos.InsertOne(todo);
            return todo;
        }

        public List<Todos> GetTodos()=>  _todos.Find(todo => true).ToList();
               
        
    }
}
