using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithLists.Models
{
    public class Todo
    {
        //constructor - ctor 
        public Todo(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // property
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }

    }
}
