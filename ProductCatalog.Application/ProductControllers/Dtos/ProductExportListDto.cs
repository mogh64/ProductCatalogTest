using Sup.Framework.Tools.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.Dtos
{
    public class ProductExportListDto : IExcelExportableDto
    {
        private readonly List<ProductOutputDto> productOutputDtos;

        public ProductExportListDto(List<ProductOutputDto> productOutputDtos)
        {
            this.productOutputDtos = productOutputDtos;
        }
        public ExcelExportInputDto GetExcelExportInputDto()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Code", typeof(long));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(decimal));
            dataTable.Columns.Add("LastUpdateTime", typeof(DateTime));
            

            dataTable.Columns["Code"].Caption ="Code";
            dataTable.Columns["Name"].Caption = "Name";
            dataTable.Columns["Price"].Caption = "Price";
            dataTable.Columns["LastUpdateTime"].Caption = "LastUpdateTime";

            List<ExcelMetaData> excelMetaDatas = new List<ExcelMetaData>();

            foreach (var product in this.productOutputDtos)
            {
                var row = dataTable.NewRow();
                row["Code"] = product.Code;
                row["Name"] = product.Name;
                row["Price"] = product.Price;
                row["LastUpdateTime"] = product.LastUpdateTime;
                dataTable.Rows.Add(row);
            }

            return new ExcelExportInputDto()
            {
                DataTable = dataTable,
                Title = ("Sup Products_" + DateTime.Now.ToLongDateString()),
                MetaDatas = excelMetaDatas
            };
        }
    }
}
