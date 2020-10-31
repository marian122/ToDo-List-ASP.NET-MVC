using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Services.ToDoS.Interfaces;
using ToDoList.Services.Users.Interfaces;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly IToDoService toDoService;
        private readonly IUsersService usersService;

        public TodoController(IToDoService toDoService, IUsersService usersService)
        {
            this.toDoService = toDoService;
            this.usersService = usersService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> All()
        {
            var userId = await this.usersService.GetUserIdAsync(this.User);
            var todos = await this.toDoService.GetAllToDosAsyncForUser<ToDosViewModel>(userId);

            var todosView = new ToDoListModel()
            {
                AllToDos = todos
            };

            return this.View(todosView);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddToDoInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = await this.usersService.GetUserIdAsync(this.User);

            input.UserId = userId;

            await this.toDoService.AddTodo(input);

            return this.RedirectToAction("All", "Todo");
        }

        [HttpGet]
        [Route("/Todo/Edit/{todoId}")]
        public async Task<IActionResult> Edit([FromRoute] string todoId)
        {
            var todo = await this.toDoService.GetTodoForEdit(todoId);

            return this.View(todo);
        }

        [HttpPost]
        [Route("/Todo/Edit/{todoId}")]
        public async Task<IActionResult> Edit([FromRoute] string todoId, EditTodoModel model)
        {
            await this.toDoService.EditTodoAsync(todoId, model);

            return this.RedirectToAction("All", "Todo");
        }

        public async Task<IActionResult> Delete(string todoId)
        {
            await this.toDoService.Delete(todoId);

            return this.RedirectToAction("All", "Todo");
        }
    }
}
