using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Models
{
    public class ShopItem : NamedEntity
    {
        [Required]
        [Range(1, 1000, ErrorMessage = "Currently available shops: Tech (1) & Groceries (2)")]
        public int ShopId { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;

        public Shop Shops { get; set; }
    }
}
