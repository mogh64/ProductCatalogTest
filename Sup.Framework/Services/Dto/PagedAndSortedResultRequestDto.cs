using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Services.Dto
{
    [Serializable]
    public class PagedAndSortedResultRequestDto : PagedResultRequestDto
    {
        public virtual string Sorting { get; set; }
    }
}
