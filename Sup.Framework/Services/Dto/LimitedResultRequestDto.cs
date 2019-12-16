using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sup.Framework.Services.Dto
{
    public class LimitedResultRequestDto 
    {
        [Range(1, int.MaxValue)]
        public virtual int MaxResultCount { get; set; } = 10;
        public virtual bool IsEnableFilter { get; set; } = true;
    }
}
