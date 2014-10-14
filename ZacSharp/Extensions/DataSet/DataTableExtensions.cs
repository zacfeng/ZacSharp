using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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
                throw new Exception("colnames.Length should equal to types.Length.");

            for(int index=0; index<colnames.Length; index++)
            {
                System.Data.DataColumn dc = new System.Data.DataColumn();
                dc.ColumnName = colnames[index];
                dc.DataType = types[index];
                dt.Columns.Add(dc);
            }
        }

        /// <summary>
        /// Return distinct table by all columns
        /// </summary>
        /// <param name="dt">this</param>
        /// <returns>Distinct table</returns>
        public static DataTable DistinctTable(this DataTable dt)
        {
            string[] columnNames = (from dc in dt.Columns.Cast<DataColumn>()
                                    select dc.ColumnName).ToArray();
            return dt.DefaultView.ToTable(true, columnNames); //remove duplicate
        }
    }
}
