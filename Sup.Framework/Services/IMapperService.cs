using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Services
{
    public interface IMapperService<TInput,TOutput,TEntity>
    {
        TEntity MapToEntity(TInput input);
        TOutput MapToDto(TEntity entity);
    }
}
