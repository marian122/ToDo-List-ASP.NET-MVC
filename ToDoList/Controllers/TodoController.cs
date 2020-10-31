using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        public TodoController()
        {
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet] 
        public IActionResult Edit()
        {
            return View();
        }
    }
}
