using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Data.Entities;
using ToDoList.Models;

namespace ToDoList.Services.ToDoS.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<TViewModel>> GetAllToDosAsync<TViewModel>();

        Task<IEnumerable<TViewModel>> GetAllToDosAsyncForUser<TViewModel>(string userId);

        Task<bool> AddTodo(AddToDoInputModel model);

        Task<EditTodoModel> GetTodoForEdit(string id);

        Task<bool> EditTodoAsync(string id, EditTodoModel model);

        ToDo GetById(string id);

        Task<bool> Delete(string id);
    }
}
