using Microsoft.AspNetCore.Mvc;
using Sup.Framework.Tools.Excel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sup.Framework.Services
{
    public interface IExcelExport<T>
    {
        Task<ExcelExportOutputDto> ExportExcel(T filter);
    }
}
