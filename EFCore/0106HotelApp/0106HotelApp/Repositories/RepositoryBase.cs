using _0106HotelApp.Data;
using _0106HotelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Repositories
{
    public abstract class RepositoryBase<T> where T : Entity
    {
        protected DataContext _context;
        private DbSet<T> _dbSet;

        protected RepositoryBase(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }
        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int entityId)
        {
            var entity = GetById(entityId);
            _context.Remove(entity);
            _context.SaveChanges();
        }


    }
}
