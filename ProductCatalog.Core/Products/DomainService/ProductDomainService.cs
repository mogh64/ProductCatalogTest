using Sup.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Products.DomainService
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public  Task<Product> Add(Product item)
        {
           var duplicatedCode = productRepository.GetAll().Any(x => x.Code == item.Code);
            if (duplicatedCode)
            {
                throw new DuplicationException("Product Code has already registered!");
            }
           return  productRepository.InsertAsync(item);
        }

        public Task Delete(Product item)
        {
            return productRepository.DeleteAsync(item);
        }

        public Task Delete(int id)
        {
            return productRepository.DeleteAsync(id);
        }

        public Task Edit(Product item)
        {

            return productRepository.UpdateAsync(item);
        }

        public Task<Product> Get(int id)
        {
            return productRepository.GetAsync(id);
        }

        public IQueryable<Product> GetAll()
        {
            return productRepository.GetAll();
        }
    }
}
