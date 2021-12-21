using _1215EFCTodoListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCTodoListApp.Dtos
{
    public class CreateTodo
    {
        public Todo Todo { get; set; } // Not good practice - entity exposed, geriau kurti tik reikalingus:
        //public string Name { get; set; }
        //public string Description { get; set; }

        public List<Category> AllCategories { get; set; }

        public List<int> SelectedTagIds { get; set; } // Will contain info on selected tags
        public List<Tag> Tags { get; set; } //Tags to display
    }
}
