using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.GlobalContstants
{
    public class InvalidOperationErrors
    {
        public const string AllTodosError = "Exception happened in ToDoService while getting all Todos from Database";

        public const string GetCurrentEdit = "Exception happened in ToDoService while getting current Todo from Database";

        public const string EditTodo = "Exception happened in ToDoService while editing ToDo";
    }
}
