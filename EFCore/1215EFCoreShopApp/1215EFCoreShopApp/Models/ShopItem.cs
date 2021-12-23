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
        public int ShopId { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;
        public Shop Shops { get; set; }
        public List<ShopItemTag> ShopItemTags { get; set; }
    }
}
