using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1209ZooApp.Models
{
    public class ZooModel
    {
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Description { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        public int Age { get; set; }

    }
}
