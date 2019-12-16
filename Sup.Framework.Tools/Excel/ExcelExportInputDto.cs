using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace Sup.Framework.Tools.Excel
{
    public class ExcelExportInputDto
    {
        public DataTable MasterDataTable { get; set; }
        public DataTable DataTable { get; set; }
        public IEnumerable<ExcelMetaData> MetaDatas { get; set; }
        public string Title { get; set; }
    }
}
