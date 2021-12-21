using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCTodoListApp.Models
{
    public class Todo : NamedEntity
    {
        [MinLength(2)]
        public string Description { get; set; }

        public Category Category { get; set; }

        public int? CategoryId { get; set; }

        public List<TodoTag> TodoTags { get; set; }


        //[NotMapped] // Vienas variantas, kai norim paduoti dropdown
        //public List<Category> AllCategories { get; set; }
    }
}
