using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Models
{
    public class ShopItemTag
    {
        public int ShopItemId { get; set; }
        public ShopItem ShopItem { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
