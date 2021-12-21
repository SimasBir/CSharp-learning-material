using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCTodoListApp.Models
{
    public class TodoTag
    {
        public int TodoId { get; set; }

        public Todo Todo { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }

    }
}
