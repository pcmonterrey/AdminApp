using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicios :Base, IServicios
    {
        private string _connectionString;
        public Servicios()
        {
            _connectionString = connectionString;
        }

        public Model.Servicios CreateServicio(Model.Servicios servicio)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    Model.Servicios objResult = new Model.Servicios();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = cn;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "InsertServicio";
                        sqlCommand.Parameters.AddWithValue("@Descripcion", servicio.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Costo", servicio.Costo);
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
                                objResult = new Model.Servicios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                    Costo = Convert.ToDecimal(reader["Costo"]),
                                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                    FechaModificacion = dtFechaModificacion
                                };
                            }
                        }
                    }
                    return objResult;
                }
                catch (Exception ex)
                {
                    return new Model.Servicios();
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public List<Model.Servicios> GetServicios(bool? onlyActive)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    List<Model.Servicios> listResult = new List<Model.Servicios>();
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
                                Model.Servicios model = new Model.Servicios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                    Costo = Convert.ToDecimal(reader["Costo"]),
                                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                    FechaModificacion = dtFechaModificacion
                                };
                                listResult.Add(model);
                            }
                        }
                    }
                    return listResult;
                }
                catch (Exception ex)
                {
                    return new List<Model.Servicios>();
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}
