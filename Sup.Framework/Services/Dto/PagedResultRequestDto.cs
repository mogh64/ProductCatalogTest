using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sup.Framework.Services.Dto
{
    [Serializable]
    public class PagedResultRequestDto : LimitedResultRequestDto
    {
        [Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }
    }
}
