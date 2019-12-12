using Sup.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Domain.Repository
{
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {

    }
}
