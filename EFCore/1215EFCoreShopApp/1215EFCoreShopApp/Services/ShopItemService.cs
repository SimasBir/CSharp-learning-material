using _1215EFCoreShopApp.Controllers;
using _1215EFCoreShopApp.Data;
using _1215EFCoreShopApp.Dtos;
using _1215EFCoreShopApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Services
{
    public class ShopItemService
    {
        public List<ShopItem> ListAll(DataContext dataContext)
        {
            List<ShopItem> items = dataContext.ShopItems.Include(i => i.Shops)
                .Include(i => i.ShopItemTags)
                .ThenInclude(sit => sit.Tag).ToList();
            return items;
        }

        public List<ShopItem> ListAllDeleted(DataContext dataContext)
        {
            List<ShopItem> items = dataContext.ShopItems.IgnoreQueryFilters().Include(i => i.Shops).Where(i => i.IsDeleted == true).ToList();
            return items;
        }

        public List<ShopItem> List(int shopId, DataContext dataContext)
        {
            List<ShopItem> items = dataContext.Shops.Include(i => i.ShopItems).Where(s => s.Id == shopId).SelectMany(i => i.ShopItems).ToList();
            return items;
        }

        public CreateShopItem ShopItemEmpty(DataContext dataContext)
        {
            CreateShopItem createShopItem = new CreateShopItem()
            {
                ShopItem = new ShopItem(),
                ShopList = dataContext.Shops.ToList(),
                Tags = dataContext.Tags.ToList(),
            };
            return createShopItem;
        }

        public void ShopItemAdd(CreateShopItem createShopItem, DataContext dataContext)
        {
            createShopItem.ShopList = dataContext.Shops.ToList();
            dataContext.ShopItems.Add(createShopItem.ShopItem);
            dataContext.SaveChanges();
            if (createShopItem.SelectedTagIds != null)
            {
                foreach (int tagId in createShopItem.SelectedTagIds)
                {
                    dataContext.ShopItemTags.Add(new ShopItemTag()
                    {
                        TagId = tagId,
                        ShopItemId = createShopItem.ShopItem.Id
                    });
                }
            }
            dataContext.SaveChanges();
        }

        public CreateShopItem ShopItemFind(int Id, DataContext dataContext)
        {
            CreateShopItem createShopItem = new CreateShopItem()
            {
                ShopItem = dataContext.ShopItems.Find(Id),
                ShopList = dataContext.Shops.ToList(),
                Tags = dataContext.Tags.ToList(),
            };
            return createShopItem;
        }

        public void ShopItemUpdate(CreateShopItem createShopItem, DataContext dataContext)
        {
            //try
            //{
            List<ShopItemTag> tagsToRemove = dataContext.ShopItemTags.Where(t => t.ShopItemId == createShopItem.ShopItem.Id).ToList();
            dataContext.ShopItemTags.RemoveRange(tagsToRemove);
            //}
            //catch { }
            dataContext.ShopItems.Update(createShopItem.ShopItem);
            dataContext.SaveChanges();

            if (createShopItem.SelectedTagIds != null)
            {
                foreach (int tagId in createShopItem.SelectedTagIds)
                {
                    ShopItemTag created = dataContext.ShopItemTags.IgnoreQueryFilters()
                        .Where(t => t.TagId == tagId)
                        .Where(a => a.ShopItemId == createShopItem.ShopItem.Id)
                        .FirstOrDefault();
                    //IgnoreQueryFilters().Include(i => i.Shops).Where(i => i.IsDeleted == true).ToList();
                    //.Find(tagId, createShopItem.ShopItem.Id);
                    //.FirstOrDefault(s => s.ShopItemId == createShopItem.ShopItem.Id);
                    //Find(tagId, createShopItem.ShopItem.Id);
                    //new ShopItemTag()
                    //{
                    //    TagId = tagId,
                    //    ShopItemId = createShopItem.ShopItem.Id
                    //});
                    if (created != null)
                    {
                        dataContext.ShopItemTags.Update(created);
                    }
                    else
                    {
                        dataContext.ShopItemTags.Add(new ShopItemTag()
                        {
                            TagId = tagId,
                            ShopItemId = createShopItem.ShopItem.Id
                        });
                    }
                }
                dataContext.SaveChanges();
            }
        }

        public void ShopItemDelete(int Id, DataContext dataContext)
        {
            ShopItem shopItem = dataContext.ShopItems.Find(Id);
            dataContext.ShopItems.Remove(shopItem);
            dataContext.SaveChanges();

            List<ShopItemTag> tagsToRemove = dataContext.ShopItemTags.Where(t => t.ShopItemId == Id).ToList();
            dataContext.ShopItemTags.RemoveRange(tagsToRemove);
            dataContext.SaveChanges();
        }
    }
}
