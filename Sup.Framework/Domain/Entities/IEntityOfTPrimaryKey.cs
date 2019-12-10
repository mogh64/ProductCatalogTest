using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Domain.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        TPrimaryKey Id { get; set; }

    }
}
