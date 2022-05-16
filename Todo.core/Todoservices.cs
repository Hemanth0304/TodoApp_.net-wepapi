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



        public void DeleteTask(string id)
        {
            _todos.DeleteOne(todo => todo.Id == id);
        }



        public List<Todos> GetDoneTodos()
        { 
            return _todos.Find(todo => todo.Status == true).ToList();
        }

        public Todos GetTask(string id) => _todos.Find(todo => todo.Id == id).First();

        public List<Todos> GetTodos()
        {
          return  _todos.Find(todo => true).ToList();
        }

      

        public Todos UpdateTask(Todos todo)
        {
            GetTask(todo.Id);
            _todos.ReplaceOne(a => a.Id == todo.Id, todo);
            return todo;
        }
    }
}
