using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1213ZooApp2.Models
{
    public class SponsorModel
    {
        public int Id { get; set; }
        [Required] 
        [StringLength(40, MinimumLength = 1)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
        [RegularExpression(@"^[0-9]*$")]
        public int Amount { get; set; }
        [Required]
        public int ZooId { get; set; }
        public string ZooName { get; set; }
    }
}
