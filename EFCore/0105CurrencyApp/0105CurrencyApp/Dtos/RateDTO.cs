using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0105CurrencyApp.Dtos
{
    public class RateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        //public string Mismatch { get; set; }
        public double CurrentRate { get; set; }
        public double PreviousRate { get; set; }
        public double RateDifference { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }
}
