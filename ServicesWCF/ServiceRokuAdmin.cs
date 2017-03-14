using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;

namespace ServicesWCF
{    
    public class ServiceRokuAdmin : IServiceRokuAdmin
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[1].ToString();
        public List<Servicios> GetServicios(bool? onlyActive)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    List<Servicios> listResult = new List<Servicios>();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = cn;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "GetServicios";
                        //sqlCommand.Parameters.Add("@Estatus", SqlDbType.Bit,Nullable);
                        //sqlCommand.Parameters["@Estatus"].Value = onlyActive;
                        sqlCommand.Parameters.AddWithValue("@Estatus", DBNull.Value);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? dtFechaModificacion = new DateTime();
                                if (!string.IsNullOrEmpty(reader["FechaModificacion"].ToString()))
                                {
                                    dtFechaModificacion = Convert.ToDateTime(reader["FechaModificacion"]);
                                }
                                else
                                {
                                    dtFechaModificacion = null;
                                }
                                Servicios model = new Servicios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                    Costo = Convert.ToDecimal(reader["Costo"]),
                                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                    FechaModificacion = dtFechaModificacion
                                    //ModelId = Convert.ToInt32(reader[0]),
                                    //FirstName = reader[1].ToString()

                                };
                                listResult.Add(model);
                            }
                        }
                    }
                    return listResult;
                }
                catch (Exception ex)
                {
                    return new List<Servicios>();
                }
                finally
                {
                    cn.Close();
                }
            }
            
        }
    }
}
