using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data.Entities;
using ToDoList.Mapping;

namespace ToDoList.Models
{
    public class ToDosViewModel : IMapFrom<ToDo>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public DateTime AlertOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

    }
}
