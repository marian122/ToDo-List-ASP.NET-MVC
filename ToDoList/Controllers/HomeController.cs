using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoList.Data.Entities;
using ToDoList.Models;
using ToDoList.Services.ToDoS;
using ToDoList.Mapping;
using Microsoft.EntityFrameworkCore;
using ToDoList.Services.ToDoS.Interfaces;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToDoService toDoService;

        public HomeController(ILogger<HomeController> logger, IToDoService toDoService)
        {
            _logger = logger;
            this.toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var todos = await this.toDoService.GetAllToDosAsync<ToDosViewModel>();

            var todosView = new ToDoListModel()
            {
                AllToDos = todos
            };

            return this.View(todosView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
