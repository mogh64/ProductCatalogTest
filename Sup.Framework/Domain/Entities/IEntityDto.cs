using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Domain.Entities
{
 
        public interface IEntityDto : IEntityDto<int>
        {

        }

        /// <summary>
        /// Defines common properties for entity based DTOs.
        /// </summary>
        /// <typeparam name="TPrimaryKey"></typeparam>
        public interface IEntityDto<TPrimaryKey>
        {
            /// <summary>
            /// Id of the entity.
            /// </summary>
            TPrimaryKey Id { get; set; }
        }
    
}
