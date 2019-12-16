using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sup.Framework.Domain
{
    public interface IDomainService<T>
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        Task<T> Add(T item);
        Task Edit(T item);
        Task Delete(T item);
        Task Delete(int id);
    }
}
