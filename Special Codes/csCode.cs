// Download excel
//- dtdata = data table
//- attached = file name
public void ExportXLS(DataTable dtdata, string attached)
        {
            string attach = attached;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attach);
            Response.ContentType = "application/ms-excel";
            if (dtdata != null)
            {
                foreach (DataColumn dc in dtdata.Columns)
                {
                    Response.Write(dc.ColumnName + "\t");
                }
                Response.Write(System.Environment.NewLine);
                foreach (DataRow dr in dtdata.Rows)
                {
                    for (int i = 0; i < dtdata.Columns.Count; i++)
                    {
                        Response.Write(dr[i].ToString() + "\t");
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
        }



//+++++++++++++++++++++++++++++++
 // covert list into DataTable
    public static class FunctionsDataTable // CS1106  
    {
        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in list)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                table.Rows.Add(values);
            }
            return table;
        }
    }



//Excel file download using DataTable
public void ExportXLS4(DataTable dtdata, string attached)
        {
            string attach = attached;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attach);
            Response.ContentType = "application/ms-excel";
            if (dtdata != null)
            {
                foreach (DataColumn dc in dtdata.Columns)
                {
                    Response.Write(dc.ColumnName + "\t");
                }
                Response.Write(System.Environment.NewLine);
                int c = 0;
                foreach (DataRow dr in dtdata.Rows)
                {
                    c++;
                    if (c == 16)
                    {

                    }
                    for (int i = 0; i < dtdata.Columns.Count; i++)
                    {
                        if (dr[i].ToString().Trim() == "LF/NRM/19/086490")
                        {

                        }

                        Response.Write(dr[i].ToString().Trim().Replace("\n", " ").Replace("\t", " ") + "\t");
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
        }
