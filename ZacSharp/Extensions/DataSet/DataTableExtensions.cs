using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZacSharp
{
    public static class DataTableExtensions
    {
        
        /// <summary>
        /// Add multiple columns to datatable
        /// </summary>
        /// <param name="dt">this</param>
        /// <param name="colnames">column names</param>
        /// <param name="types">types</param>
        public static void AddColumns(this System.Data.DataTable dt, string[] colnames, System.Type[] types)
        {
            if (colnames.Length != types.Length)
                throw new Exception("colnames.Length != types.Length");

            for(int index=0; index<colnames.Length; index++)
            {
                System.Data.DataColumn dc = new System.Data.DataColumn();
                dc.ColumnName = colnames[index];
                dc.DataType = types[index];
                //dc.DataType = System.Type.GetType("System.String");
                dt.Columns.Add(dc);
            }
        }
    }
}
