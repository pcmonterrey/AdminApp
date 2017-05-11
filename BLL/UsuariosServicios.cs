using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class UsuariosServicios : Base, IUsuariosServicios
    {
        private string _connectionString;
        public UsuariosServicios()
        {
            _connectionString = connectionString;
        }

        public Model.UsuariosServicios CreateUsuarioServicio(Model.UsuariosServicios usuarioServicio)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    Model.UsuariosServicios objResult = new Model.UsuariosServicios();
                    using (SqlCommand sqlcommand = new SqlCommand())
                    {
                        sqlcommand.Connection = cn;
                        sqlcommand.CommandType = CommandType.StoredProcedure;
                        sqlcommand.CommandText = "InsertUsuarioServicio";
                        sqlcommand.Parameters.AddWithValue("@IdServicio", usuarioServicio.IdServicio);
                        sqlcommand.Parameters.AddWithValue("@IdUsuario", usuarioServicio.IdUsario);
                        sqlcommand.Parameters.AddWithValue("@FechaCreacion", usuarioServicio.FechaCreacion);
                        sqlcommand.Parameters.AddWithValue("@FechaInicioServicio", usuarioServicio.FechaInicioServicio);
                        sqlcommand.Parameters.AddWithValue("@FechaFinServicio", usuarioServicio.FechaFinServicio);
                        sqlcommand.Parameters.AddWithValue("@NumerosCreditos", usuarioServicio.NumeroCreditos);
                        sqlcommand.Parameters.AddWithValue("@Estado",usuarioServicio.Estado);
                        //sqlcommand.Parameters.AddWithValue("@Contrasena", usuarioServicio);
                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? dtFechaModificacion = new DateTime();
                                if (!String.IsNullOrEmpty(reader["FechaModificacion"].ToString()))
                                {
                                    dtFechaModificacion = Convert.ToDateTime(reader["FechaModificacion"]);
                                }
                                else
                                {
                                    dtFechaModificacion = null;
                                }
                                objResult = new Model.UsuariosServicios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    IdUsario= Convert.ToInt32(reader["IdUsuario"]),
                                    IdServicio= Convert.ToInt32(reader["IdServicio"]),
                                    FechaInicioServicio= Convert.ToDateTime(reader["FechaInicioServicio"]),
                                    FechaFinServicio= Convert.ToDateTime(reader["FechaFinServicio"]),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                    FechaModificacion = dtFechaModificacion
                                    
                                };
                            }
                        }
                    }
                    return objResult;
                }
                catch (Exception e)
                {
                    return new Model.UsuariosServicios();
                }
                finally
                {
                    cn.Close();
                }
            }
        }


        public List<Model.GetUsuariosServicios> GetUsuariosServicios(bool? onlyActive)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    List<Model.GetUsuariosServicios> listResult = new List<Model.GetUsuariosServicios>();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = cn;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "GetUsuariosServicios";
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

                                /*Model.GetUsuariosServicios consulta = new Model.GetUsuariosServicios
                                {
                                    Id = Convert.ToInt32(reader["UsuariosServicios.Id"]),
                                    
                                    Estado = Convert.ToBoolean(reader["UsuariosServicios.Estado"]),
                                    FechaCreacion = Convert.ToDateTime(reader["UsuariosServicios.FechaCreacion"]),
                                    FechaModificacion = dtFechaModificacion,
                                    FechaInicioServicio = Convert.ToDateTime(reader["UsuariosServicios.FechaInicioServicio"]),
                                    FechaFinServicio = Convert.ToDateTime(reader["UsuariosServicios.FechaFinServicio"]),
                                    NumeroCreditos = Convert.ToInt16(reader["UsuariosServicios.NumeroCreditos"])
                                };
                                */
                                Model.GetUsuariosServicios model = new Model.GetUsuariosServicios
                                {
                                    
                                    Id = Convert.ToInt32(reader["Id"]),
                                    NombreUsuario = reader["NombreUsuario"].ToString(),
                                    DescripcionServicio = reader["DescripcionServicio"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                    FechaModificacion = dtFechaModificacion,
                                    FechaInicioServicio = Convert.ToDateTime(reader["FechaInicioServicio"]),
                                    FechaFinServicio = Convert.ToDateTime(reader["FechaFinServicio"]),
                                    NumeroCreditos = Convert.ToInt16(reader["NumeroCreditos"])

                                };
                                listResult.Add(model);
                            }
                        }

                    }
                    return listResult;
                }
                catch (Exception ex)
                {
                    return new List<Model.GetUsuariosServicios>();
                }
                finally
                {
                    cn.Close();
                }

            }
        }

        public Model.UsuariosServicios EditUsuarioServicio(Model.UsuariosServicios usuarioServicio)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    Model.UsuariosServicios objResult = new Model.UsuariosServicios();
                    using (SqlCommand sqlcommand = new SqlCommand())
                    {
                        sqlcommand.Connection = cn;
                        sqlcommand.CommandType = CommandType.StoredProcedure;
                        sqlcommand.CommandText = "EditUsuario";
                        sqlcommand.Parameters.AddWithValue("@Id", usuarioServicio.Id);
                        //sqlcommand.Parameters.AddWithValue("@Nombre", usuarioServicio.Nombre);
                        //sqlcommand.Parameters.AddWithValue("@FechaMod", SqlDbType.DateTime);
                        //sqlcommand.Parameters.AddWithValue("@Usuario", usuarioServicio.Usuario);
                        //sqlcommand.Parameters.AddWithValue("@Contrasena", usuarioServicio.Contrasena);
                        sqlcommand.Parameters.AddWithValue("@Estado", usuarioServicio.Estado);
                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? dtFechaModificacion = new DateTime();
                                if (!String.IsNullOrEmpty(reader["FechaMod"].ToString()))
                                {
                                    dtFechaModificacion = Convert.ToDateTime(reader["FechaMod"]);
                                }
                                else
                                {
                                    dtFechaModificacion = Convert.ToDateTime(reader["FechaMod"]);
                                }
                                objResult = new Model.UsuariosServicios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    //Nombre = reader["Nombre"].ToString(),
                                    //Usuario = reader["Usuario"].ToString(),
                                    //Contrasena = reader["Contraseña"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                    FechaModificacion = dtFechaModificacion

                                };
                            }
                        }
                    }
                    return objResult;
                }
                catch (Exception e)
                {
                    return new Model.UsuariosServicios();
                }
                finally
                {
                    cn.Close();
                }
            }
        }

       public Model.UsuariosServicios DeleteUsuarioServicio(Model.UsuariosServicios usuarioServicio) {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    Model.UsuariosServicios objResult = new Model.UsuariosServicios();
                    using (SqlCommand sqlcommand = new SqlCommand())
                    {
                        sqlcommand.Connection = cn;
                        sqlcommand.CommandType = CommandType.StoredProcedure;
                        sqlcommand.CommandText = "EditUsuario";
                        sqlcommand.Parameters.AddWithValue("@Id", usuarioServicio.Id);
                        //sqlcommand.Parameters.AddWithValue("@Nombre", usuarioServicio.Nombre);
                        //sqlcommand.Parameters.AddWithValue("@FechaMod", SqlDbType.DateTime);
                        //sqlcommand.Parameters.AddWithValue("@Usuario", usuarioServicio.Usuario);
                        //sqlcommand.Parameters.AddWithValue("@Contrasena", usuarioServicio.Contrasena);
                        sqlcommand.Parameters.AddWithValue("@Estado", usuarioServicio.Estado);
                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? dtFechaModificacion = new DateTime();
                                if (!String.IsNullOrEmpty(reader["FechaMod"].ToString()))
                                {
                                    dtFechaModificacion = Convert.ToDateTime(reader["FechaMod"]);
                                }
                                else
                                {
                                    dtFechaModificacion = Convert.ToDateTime(reader["FechaMod"]);
                                }
                                objResult = new Model.UsuariosServicios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    //Nombre = reader["Nombre"].ToString(),
                                    //Usuario = reader["Usuario"].ToString(),
                                    //Contrasena = reader["Contraseña"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                    FechaModificacion = dtFechaModificacion

                                };
                            }
                        }
                    }
                    return objResult;
                }
                catch (Exception e)
                {
                    return new Model.UsuariosServicios();
                }
                finally
                {
                    cn.Close();
                }
            }
        }

    }
}
