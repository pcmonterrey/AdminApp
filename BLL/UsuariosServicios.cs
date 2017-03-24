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
                        //sqlcommand.Parameters.AddWithValue("@Id", usuarioServicio);
                        //sqlcommand.Parameters.AddWithValue("@Usuario", usuarioServicio);
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
                                    //Nombre = reader["Nombre"].ToString(),
                                    //Usuario = reader["Usuario"].ToString(),
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


        public List<Model.UsuariosServicios> GetUsuariosServicios(bool? onlyActive)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    List<Model.UsuariosServicios> listResult = new List<Model.UsuariosServicios>();
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

                                Model.UsuariosServicios model = new Model.UsuariosServicios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    //Nombre = reader["Nombre"].ToString(),
                                    //Usuario = reader["Usuario"].ToString(),
                                    //Contrasena = reader["Contrasena"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
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
                    return new List<Model.UsuariosServicios>();
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

    }
}
