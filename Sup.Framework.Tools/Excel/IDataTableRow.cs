using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sup.Framework.Tools.Excel
{
    public interface IExcelExportRow
    {
        void AddRowToExcelExport(DataTable dataTable,List<ExcelMetaData>metaDatas);
    }
}
