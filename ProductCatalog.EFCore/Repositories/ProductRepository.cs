using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.EFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductCatalogDbContext dbContext;

        public ProductRepository(ProductCatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task DeleteAsync(Product entity)
        {
            this.dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var entity = await this.dbContext.Products.FindAsync(id);
            this.dbContext.Remove(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public Task<Product> FirstOrDefaultAsync(int id)
        {
            return Task.FromResult(this.dbContext.Products.FirstOrDefault(x => x.Id == id));
        }

        public Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> predicate)
        {
            return Task.FromResult(this.dbContext.Products.FirstOrDefault(predicate));
        }

        public IQueryable<Product> GetAll()
        {
            return this.dbContext.Products.AsQueryable().AsNoTracking();
        }

        public  Task<List<Product>> GetAllListAsync()
        {
            return this.dbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await this.dbContext.Products.FindAsync(id);
        }

        public async Task<Product> InsertAsync(Product entity)
        {
            this.dbContext.Products.Add(entity);
            await this.dbContext.SaveChangesAsync();
            return entity;
        }

        public Task<Product> SingleAsync(Expression<Func<Product, bool>> predicate)
        {
            return  this.dbContext.Products.SingleAsync(predicate);
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            var local = dbContext.Set<Product>()
                                    .Local
                                  .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                dbContext.Entry(local).State = EntityState.Detached;
            }
            this.dbContext.Set<Product>().Update(entity);
            await this.dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
