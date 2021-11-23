using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithLists.Models
{
    public class Todo
    {
        // variables/field
        public string NameVariable = "";

        // property
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
