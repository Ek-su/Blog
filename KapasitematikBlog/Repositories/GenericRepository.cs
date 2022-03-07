using KapasitematikBlog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KapasitematikBlog.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        KapasitematikBlogDbContext _dbContext = new KapasitematikBlogDbContext();

        public List<T> TList()
        {
            return _dbContext.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            _dbContext.Set<T>().Add(p);
            _dbContext.SaveChanges();
        }
        public void TDelete(T p)
        {
            _dbContext.Set<T>().Remove(p);
            _dbContext.SaveChanges();
        }
        public void TUpdate(T p)
        {
            _dbContext.Set<T>().Update(p);
            _dbContext.SaveChanges();
        }
        public T TGet(int id)
        {
           return _dbContext.Set<T>().Find(id);
        }
        public List<T> TList(string p)
        {
            return _dbContext.Set<T>().Include(p).ToList();
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().Where(filter).ToList();
        }
    }
}

