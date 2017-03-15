using Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ServicesWCF
{    
    public class ServiceRokuAdmin : IServiceRokuAdmin
    {
        public List<Servicios> GetServicios(bool? onlyActive)
        {
            BLL.AdminRoku oBussinessAdminRoku = new BLL.AdminRoku();
            List<Model.Servicios> response = oBussinessAdminRoku.GetServicios(onlyActive);
            return response;
        }
    }
}
