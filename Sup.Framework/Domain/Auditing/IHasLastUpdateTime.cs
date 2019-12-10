using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Domain.Auditing
{
    public interface IHasLastUpdateTime
    {
        /// <summary>
        /// The last modified time for this entity.
        /// </summary>
        DateTime? LastUpdateTime { get; set; }
    }
}
