using _1215EFCoreShopApp.Data;
using _1215EFCoreShopApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Services
{
    public class GenericService
    {
        //public Generic<T> ListAll(DataContext dataContext)
        //{
        //    T[] tags = dataContext.Tags.IgnoreQueryFilters().ToList();
        //    return tags;
        //}
        public void TagAdd(Tag tag, DataContext dataContext)
        {
            dataContext.Tags.Add(tag);
            dataContext.SaveChanges();
        }

        public void TagUpdate(Tag tag, DataContext dataContext)
        {
            dataContext.Tags.Update(tag);
            dataContext.SaveChanges();
        }

        public void TagDelete(int Id, DataContext dataContext)
        {
            Tag tag = dataContext.Tags.Find(Id);
            dataContext.Tags.Remove(tag);
            dataContext.SaveChanges();
        }

        public void TagReactivate(int Id, DataContext dataContext)
        {
            Tag tag = dataContext.Tags.IgnoreQueryFilters().Single(x => x.Id == Id);
            tag.IsDeleted = false;
            dataContext.SaveChanges();
        }
    }
}
