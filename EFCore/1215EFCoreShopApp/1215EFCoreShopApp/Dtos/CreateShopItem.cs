using _1215EFCoreShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Dtos
{
    public class CreateShopItem
    {
        public ShopItem ShopItem { get; set; }
        public List<Shop> ShopList { get; set; }
    }
}
