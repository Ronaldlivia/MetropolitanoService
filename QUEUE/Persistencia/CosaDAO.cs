using QUEUE.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QUEUE.Persistencia
{
    public class CosaDAO
    {
        private string cnData = ConfigurationManager.ConnectionStrings["cnData"].ConnectionString;

        public bool Registrar(string nombre, int cantidad)
        {
            bool exito = false;

            using (SqlConnection sqlCn = new SqlConnection(cnData))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("dbo.Cosa_Registrar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = nombre;
                    sqlCmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = cantidad;

                    if (sqlCmd.ExecuteNonQuery() > 0)
                    {
                        exito = true;
                    }
                }
            }

            return exito;
        }

        public List<ListaCosaResponse> Consultar(string nombre)
        {
            List<ListaCosaResponse> lstListaCosaResponse = new List<ListaCosaResponse>();

            using (SqlConnection sqlCn = new SqlConnection(cnData))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("dbo.Cosa_Listar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = nombre;

                    SqlDataReader sqlDr = sqlCmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (sqlDr != null)
                    {
                        if (sqlDr.HasRows)
                        {
                            ListaCosaResponse objListaCosaResponse;

                            while(sqlDr.Read())
                            {
                                objListaCosaResponse = new ListaCosaResponse();
                                objListaCosaResponse.Nombre = sqlDr.GetString(sqlDr.GetOrdinal("Nombre"));
                                objListaCosaResponse.Cantidad = sqlDr.GetInt32(sqlDr.GetOrdinal("Cantidad"));
                                lstListaCosaResponse.Add(objListaCosaResponse);
                            }
                        }
                    }
                }
            }

            return lstListaCosaResponse;
        }
    }
}