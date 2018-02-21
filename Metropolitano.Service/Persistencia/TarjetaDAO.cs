using Metropolitano.Service.Dominio;
using Metropolitano.Service.Utilitario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Metropolitano.Service.Persistencia
{
    public class TarjetaDAO
    {
        public Tarjeta Consultar(string codigoTarjeta)
        {
            Tarjeta objTarjeta = new Tarjeta();

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetropolitano))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("dbo.Tarjeta_Consultar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@CodigoTarjeta", SqlDbType.VarChar, 25).Value = codigoTarjeta;

                    SqlDataReader sqlDr = sqlCmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (sqlDr != null)
                    {
                        if (sqlDr.HasRows)
                        {
                            if (sqlDr.Read())
                            {
                                objTarjeta.IdTarjeta = sqlDr.GetInt32(sqlDr.GetOrdinal("IdTarjeta"));
                                objTarjeta.CodigoTarjeta = sqlDr.GetString(sqlDr.GetOrdinal("CodigoTarjeta"));
                                objTarjeta.FechaVigencia = sqlDr.GetDateTime(sqlDr.GetOrdinal("FechaVigencia"));
                                objTarjeta.Estado = sqlDr.GetBoolean(sqlDr.GetOrdinal("Estado"));
                            }                            
                        }
                    }
                }
            }

            return objTarjeta;
        }

        public bool ActualizarTarjeta(string codigoTarjeta)
        {
            bool exito = false;

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetropolitano))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("dbo.Tarjeta_Actualizar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@nrotarjeta", SqlDbType.VarChar, 15).Value = codigoTarjeta;
                   

                    if (sqlCmd.ExecuteNonQuery() > 0)
                    {
                        exito = true;
                    }
                }
            }

            return exito;
        }

  
    }
}