using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using ClosedXML.Excel;

namespace sio_console
{
    public class FileOperations
    {
        public static string SaveExceltoCSV(string FileName)
        {
            string csvFilename = FileName.Replace("xlsx", "csv");
            
            XLWorkbook workBook = new XLWorkbook(FileName);
            
            var worksheet = workBook.Worksheet(1);
            File.WriteAllLines(csvFilename, worksheet.RowsUsed().Select(row => string.Join("^", row.Cells(1, row.LastCellUsed(false).Address.ColumnNumber).Select(cell => cell.GetValue<string>()))), System.Text.Encoding.GetEncoding(1250));
            workBook = null;
            
            return csvFilename;
        }

        public static DataTable  csvToDatatable(string filename, string separator, int PomijajPierwszeWierszeIlosc = 0, int ii = 1)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            bool firstLine = true;
            if (System.IO.File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.GetEncoding(1250)))
                {
                    int i = 1;
                    if (ii != 1)
                        i = ii;
                    while (!sr.EndOfStream)
                    {
                        if (firstLine)
                        {
                            if (i > PomijajPierwszeWierszeIlosc)
                            {
                                firstLine = false;
                                var cols = sr.ReadLine().Split(separator);
                                foreach (var col in cols)
                                    dt.Columns.Add(new DataColumn(col, typeof(string)));
                            }
                            else
                                sr.ReadLine().Split(separator);
                        }
                        else
                        {
                            string[] data = sr.ReadLine().Split(separator);
                            if (data.Length > dt.Columns.Count)
                                dt.Columns.Add("col_" + dt.Columns.Count);
                            dt.Rows.Add(data.ToArray());
                        }


                        i += 1;
                    }
                }
            }
            return dt;
        }


    }
}
