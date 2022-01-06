using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0105CurrencyApp.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

    }
}
