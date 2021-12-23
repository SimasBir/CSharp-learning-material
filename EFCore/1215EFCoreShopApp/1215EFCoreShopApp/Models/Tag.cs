using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Models
{
    public class Tag : NamedEntity
    {
        public List<ShopItemTag> ShopItemsTags { get; set; }
    }
}
