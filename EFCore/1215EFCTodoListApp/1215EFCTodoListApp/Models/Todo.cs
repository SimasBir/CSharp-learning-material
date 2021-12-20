using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
