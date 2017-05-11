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
    public class Usuarios : Base, IUsuarios
    {
        private string _connectionString;
        public Usuarios()
        {
            _connectionString = connectionString;
        }

        public Model.Usuarios CreateUsuario(Model.Usuarios usuario)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    Model.Usuarios objResult = new Model.Usuarios();
                    using (SqlCommand sqlcommand = new SqlCommand())
                    {
                        sqlcommand.Connection = cn;
                        sqlcommand.CommandType = CommandType.StoredProcedure;
                        sqlcommand.CommandText = "InsertUsuario";
                        sqlcommand.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        sqlcommand.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                        sqlcommand.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                        sqlcommand.Parameters.AddWithValue("@Estado", usuario.Estado);
                        sqlcommand.Parameters.AddWithValue("@FechaCreacion", usuario.FechaCreacion);
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
                                objResult = new Model.Usuarios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Usuario = reader["Usuario"].ToString(),
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
                    return new Model.Usuarios();
                }
                finally
                {
                    cn.Close();
                }
            }
        }


        public List<Model.Usuarios> GetUsuarios(bool? onlyActive)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    List<Model.Usuarios> listResult = new List<Model.Usuarios>();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = cn;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "GetUsuarios";
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

                                Model.Usuarios model = new Model.Usuarios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Usuario = reader["Usuario"].ToString(),
                                    Contrasena = reader["Contrasena"].ToString(),
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
                catch(Exception ex)
                {
                    return new List<Model.Usuarios>();
                }
                finally
                {
                    cn.Close();
                }

            }
        }

        public Model.Usuarios EditUsuario(Model.Usuarios usuario)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    Model.Usuarios objResult = new Model.Usuarios();
                    using (SqlCommand sqlcommand = new SqlCommand())
                    {
                        sqlcommand.Connection = cn;
                        sqlcommand.CommandType = CommandType.StoredProcedure;
                        sqlcommand.CommandText = "EditUsuario";
                        sqlcommand.Parameters.AddWithValue("@Id", usuario.Id);
                        sqlcommand.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        sqlcommand.Parameters.AddWithValue("@FechaMod", SqlDbType.DateTime);
                        sqlcommand.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                        sqlcommand.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                        sqlcommand.Parameters.AddWithValue("@Estado", usuario.Estado);
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
                                objResult = new Model.Usuarios
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Usuario = reader["Usuario"].ToString(),
                                    Contrasena = reader["Contraseña"].ToString(),
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
                    return new Model.Usuarios();
                }
                finally
                {
                    cn.Close();
                }
            }
        }

    }
}