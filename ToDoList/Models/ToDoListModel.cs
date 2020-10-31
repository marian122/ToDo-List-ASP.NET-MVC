using Abp.AutoMapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Mapping;

namespace ToDoList.Models
{
    public class ToDoListModel
    {
        public IEnumerable<ToDosViewModel> AllToDos { get; set; }

        
    }
}
