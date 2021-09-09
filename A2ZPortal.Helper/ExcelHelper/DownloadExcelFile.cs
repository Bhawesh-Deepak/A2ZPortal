using ClosedXML.Excel;
using Fingers10.ExcelExport.ActionResults;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Helper.ExcelHelper
{
    public static class DownloadExcelFile<T> where T : class
    {
        public static MemoryStream GetExcelFile(IEnumerable<T> result, string sheetName, string excelFileName)
        {
            var dataTable = ToDataTable(result);

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable, sheetName);
                using MemoryStream stream = new MemoryStream();
                wb.SaveAs(stream);
                //
                return stream;
            }
        }

        public static DataTable ToDataTable(IEnumerable<T> self)
        {
            var properties = typeof(T).GetProperties();

            var dataTable = new DataTable();

            foreach (var info in properties)
            {
                dataTable.Columns.Add(info.Name, Nullable.GetUnderlyingType(info.PropertyType)
                         ?? info.PropertyType);
            }


            foreach (var entity in self)
                dataTable.Rows.Add(properties.Select(p => p.GetValue(entity)).ToArray());

            return dataTable;
        }
    }
}
