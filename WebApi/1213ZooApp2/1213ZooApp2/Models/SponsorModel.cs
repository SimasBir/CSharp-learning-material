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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Amount { get; set; }
        public int ZooId { get; set; }
        public string ZooName { get; set; }
    }
}
