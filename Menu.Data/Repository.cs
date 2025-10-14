using Menu.Entities.Helper;
using ReportApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Repository
{
    public class Repository<T> where T : class, IIdEntity
    {
        ReportAppContext ctx;

        public Repository(ReportAppContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void CreateMany(IEnumerable<T> entities)
        {
            ctx.Set<T>().AddRange(entities);
            ctx.SaveChanges();
        }

        public async Task CreateManyAsync(IEnumerable<T> entities)
        {
            ctx.Set<T>().AddRange(entities);
            await ctx.SaveChangesAsync();
        }

        public T FindById(string id)
        {
            return ctx.Set<T>().First(t => t.Id == id);
        }


        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

    }
}
