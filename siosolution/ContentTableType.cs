using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace siosolution
{
    public class ContentTableType:ContentType
    {
        public DataTable Table { get; set; }


        public void EditCell(int RowIndex,int ColumnIndex,object value)
        {
            this.Table.Rows[RowIndex][ColumnIndex] = value;
        }
    }
}
