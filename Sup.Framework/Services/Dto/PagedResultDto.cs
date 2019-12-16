using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Services.Dto
{
    public class PagedResultDto<T>
    {
        public PagedResultDto()
        {

        }
        public IReadOnlyList<T> ResultList { get; set; }
        public int TotalCount { get; set; }
    }
}
