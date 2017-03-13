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

namespace ServicesWCF
{
    public class ServiceRokuAdmin : IServiceRokuAdmin
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[1].ToString();
        public List<Servicios> GetServicios(bool? onlyActive)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetServicios";
                sqlCommand.Parameters.Add(new SqlParameter("@Esatus", onlyActive));
                sqlCommand.Connection = cn;
                return (List<Servicios>)sqlCommand.ExecuteScalar();
            }            
        }
    }
}
