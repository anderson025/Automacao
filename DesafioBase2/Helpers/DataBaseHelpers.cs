using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioBase2.Helpers
{
    public class DataBaseHelpers
    {
        private static SqlConnection GetDBConnection()
        {
            string connectionString = "Data Source=" + BuilderJson.ReturnParameterAppSettings("DB_URL") + "," + BuilderJson.ReturnParameterAppSettings("DB_PORT") + ";" +
                                      "Initial Catalog=" + BuilderJson.ReturnParameterAppSettings("DB_NAME") + ";" +
                                      "User ID=" + BuilderJson.ReturnParameterAppSettings("DB_USER") + "; " +
                                      "Password=" + BuilderJson.ReturnParameterAppSettings("DB_PASSWORD") + ";";
          
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        private static MySqlConnection GetDBConnectionMySQL()
        {
            string connectionString = "server=" + BuilderJson.ReturnParameterAppSettings("DB_URL") + "," + BuilderJson.ReturnParameterAppSettings("DB_PORT") + ";" +
                                      "database=" + BuilderJson.ReturnParameterAppSettings("DB_NAME") + ";" +
                                      "uid=" + BuilderJson.ReturnParameterAppSettings("DB_USER") + "; " +
                                      "password=" + BuilderJson.ReturnParameterAppSettings("DB_PASSWORD") + ";" +
                                      "port=" + BuilderJson.ReturnParameterAppSettings("DB_PORT") + ";";
                                      //"DB_SslMode=" + BuilderJson.ReturnParameterAppSettings("DB_SslMode") + ";";
                
            MySqlConnection connection = new MySqlConnection(connectionString + "DB_SslMode=" + null + ";");

            return connection;
        }


        public static void ExecuteQuery(string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, GetDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(BuilderJson.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public static List<string> RetornaDadosQuery(string query)
        {
            DataSet ds = new DataSet();
            List<string> lista = new List<string>();

            using (SqlCommand cmd = new SqlCommand(query, GetDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(BuilderJson.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));
                cmd.Connection.Open();

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);

                cmd.Connection.Close();
            }

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                        
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return lista;
        }


        public static List<string> RetornaDadosUsuario()
        {
            List<string> lista = new List<string>();           

            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;database=bugtracker;uid=mantisbt;pwd=mantisbt;port=3306;;SslMode=none");

            connection.Open();
            MySqlCommand SELECT = connection.CreateCommand();
            SELECT.CommandType = CommandType.Text;
            SELECT.CommandText = "SELECT username, password FROM mantis_user_table WHERE username = @usuario ";
            SELECT.Parameters.AddWithValue("@usuario", "administrator");


            MySqlDataReader leitura = SELECT.ExecuteReader();

            if (leitura.Read())
            {
                lista.Add(leitura[0].ToString());
                //lista.Add(leitura[1].ToString());                
            }

            return lista;        



        }
    }
}
