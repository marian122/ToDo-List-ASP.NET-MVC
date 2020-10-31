using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Data.Entities
{
    public class ToDo
    {
        public ToDo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public DateTime AlertOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }


    }
}
