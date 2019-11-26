using Backend.Infrastructura.ProcedimientosAlmacenados.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Backend.Infrastructura
{
    public class SqlStoredProcedureServiceManager
    {
        public async Task<List<T>> Get<T>(string uri)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);
            bool responseWasWrong = !response.IsSuccessStatusCode;
            if (responseWasWrong)
            {
                return null;
            }

            string jsonString = await response.Content.ReadAsStringAsync(); 
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                         
            return JSserializer.Deserialize<List<T>>(jsonString);
        }

        private DataTable GetDataTable(string query)
        {
          
                SqlDataAdapter adapter = new SqlDataAdapter(query,SQLConfiguration.GetDbString());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                SQLConfiguration.Close();
                return dataTable;
            
        }

        public DataTable GetDataByStoredProcedure(CommandSender cmdSnd)
        {

            using (SqlDataAdapter sda = new SqlDataAdapter(cmdSnd.GetCommand()))
            {

                DataTable dt = new DataTable();
                sda.Fill(dt);
                SQLConfiguration.Close();
                return dt;
            }

        }

        public List<T> GetAnyDataByCommand<T>(CommandSender cmdSender)
        {
            DataTable table = GetDataByStoredProcedure(cmdSender);
            return ConvertToList<T>(table);
        }


        public List<T> ConvertToList<T>(DataTable dataTable)
        {
            var columnNames = dataTable.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();

            return dataTable.AsEnumerable().Select(row =>
            {
                var objectType = Activator.CreateInstance<T>();
                foreach (var prop in properties)
                {
                    if (columnNames.Contains(prop.Name))
                    {
                        PropertyInfo propInfo = objectType.GetType().GetProperty(prop.Name);


                        prop.SetValue(objectType, row[prop.Name] == DBNull.Value ? null : Convert.ChangeType(row[prop.Name], propInfo.PropertyType));
                    }
                }
                return objectType;
            }).ToList();
        }
    }
}
