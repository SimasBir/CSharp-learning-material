using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1213ZooApp2.Models
{
    public class ZooModel2
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; }
        [StringLength(80)]
        public string Description { get; set; }
        [StringLength(40)]
        public string Gender { get; set; }
        [Range(1, 1000)]
        public int Age { get; set; }
    }
}
