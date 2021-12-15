using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCTodoListApp.Models
{
    public class Category : NamedEntity
    {
        public List<Todo> Todos { get; set; }
    }
}
