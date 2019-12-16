using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Sup.Framework.Tools.Excel
{
    public class ExcelExportBuilder
    {
        public async Task<ExcelExportOutputDto> CreateExcelExport(ExcelExportInputDto inputDto)
        {
            return await Task.Run(() =>
             {

                 using (ExcelPackage excelPackage = new ExcelPackage())
                 {
                     ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                     if (inputDto.MasterDataTable != null)
                     {
                         worksheet.Cells["A1"].LoadFromDataTable(inputDto.MasterDataTable, true);
                     }
                     worksheet.Cells["A3"].LoadFromDataTable(inputDto.DataTable, true);
                     int rows=  worksheet.Cells["A3"].Rows;
                     int startRow = worksheet.Cells["A3"].Start.Row;
                     worksheet.DefaultColWidth = 30;
                     
                     worksheet.View.RightToLeft = true;
                     worksheet.View.ShowHeaders = true;

                     foreach (var metaData in inputDto.MetaDatas)
                     {
                         if (metaData.BackGroundColor.HasValue)
                         {
                             int currentRow = startRow + metaData.Row;
                            //worksheet.Row(metaData.Row+1).Style.Fill.PatternType = ExcelFillStyle.Solid;
                            //worksheet.Row(metaData.Row+1).Style.Fill.BackgroundColor.SetColor(metaData.BackGroundColor.Value);
                            worksheet.Row(currentRow).Style.Font.Color.SetColor(metaData.BackGroundColor.Value);
                             worksheet.Row(currentRow).Style.WrapText = metaData.WrapText;
                         }
                     }
                     byte[] byteData = excelPackage.GetAsByteArray();
                     return new ExcelExportOutputDto()
                     {
                         Data = Convert.ToBase64String(byteData),
                         Extension = ".xlsx",
                         Name = String.IsNullOrWhiteSpace(inputDto.Title) ? "excelOutputResult" : inputDto.Title
                     };
                 }

             });

        }

    }
}
