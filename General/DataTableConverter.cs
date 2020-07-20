using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace UniversitasApp.General
{
    /// <summary>
    /// Mengubah List menjadi DataTable
    /// </summary>
    public class DataTableConverter
    {
        /// <summary>
        /// Mengconvert list menjadi datatable
        /// </summary>
        /// <param name="data">data list</param>
        /// <returns>table</returns>
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}