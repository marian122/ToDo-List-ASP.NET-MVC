using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Services.ToDoS.Interfaces;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly IToDoService toDoService;

        public TodoController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        [HttpGet]
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

            await this.toDoService.AddTodo(input);

            return this.RedirectToAction("Index", "Home");
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

            return this.RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(string todoId)
        {
            await this.toDoService.Delete(todoId);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
