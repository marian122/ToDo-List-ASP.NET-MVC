namespace ToDoList.Services.ToDoS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ToDoList.Data.Entities;
    using ToDoList.Services.ToDoS.Interfaces;
    using ToDoList.Mapping;
    using ToDoList.Data;
    using ToDoList.Models;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class ToDoService : IToDoService
    {
        private readonly ApplicationDbContext db;

        public ToDoService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddTodo(AddToDoInputModel model)
        {
            var result = new ToDo()
            {
                Description = model.Description,
                AlertOn = model.AlertOn,
                CreatedOn = DateTime.Now,
                IsActive = true,
                UserId = model.UserId,
            };

            await this.db.AddAsync(result);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var result = this.GetById(id);
            this.db.Todos.Remove(result);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditTodoAsync(string id, EditTodoModel model)
        {
            var todo = this.GetById(id);

            if (todo != null)
            {
                todo.Description = model.Description;
                todo.AlertOn = model.AlertOn;
                todo.CreatedOn = DateTime.Now;

                this.db.Todos.Update(todo);

                await this.db.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalContstants.InvalidOperationErrors.EditTodo);
        }

        public async Task<IEnumerable<TViewModel>> GetAllToDosAsync<TViewModel>()
        {
            var result = await this.db.Todos.OrderBy(x => x.CreatedOn)
                .Where(x => x.IsActive == true)
                .To<TViewModel>()
                .ToListAsync();

            
            if (result != null)
            {
                return result;
            }

            throw new InvalidOperationException(GlobalContstants.InvalidOperationErrors.AllTodosError);
        }

        public async Task<IEnumerable<TViewModel>> GetAllToDosAsyncForUser<TViewModel>(string userId)
        {
            var result = await this.db.Todos.OrderBy(x => x.CreatedOn)
                .Where(x => x.UserId == userId && x.AlertOn >= DateTime.Now)
                .To<TViewModel>()
                .ToListAsync();


            if (result != null)
            {
                return result;
            }
            throw new InvalidOperationException(GlobalContstants.InvalidOperationErrors.AllTodosError);

        }

        public ToDo GetById(string id)
            => this.db.Todos.Where(x => x.Id == id).First();

        public async Task<EditTodoModel> GetTodoForEdit(string id)
        {
            var toDo = this.GetById(id);

            if (toDo != null)
            {
                var result = new EditTodoModel()
                {
                    Description = toDo.Description,
                    AlertOn = toDo.AlertOn,
                    IsActive = toDo.IsActive
                };
                
                return result;
            }

            throw new InvalidOperationException(GlobalContstants.InvalidOperationErrors.GetCurrentEdit);
        }
        
        public List<ToDo> GetTodosList()
            => this.db.Todos.ToList();
    }
}
