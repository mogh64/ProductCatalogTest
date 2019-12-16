using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Tools.Excel
{
    public interface IExcelExportableDto
    {
        ExcelExportInputDto GetExcelExportInputDto();
    }
}
