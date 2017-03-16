using Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ServicesWCF
{    
    public class Servicios : IServicios
    {
        private BLL.Servicios oBussinessAdminRoku;
        public Servicios()
        {
            oBussinessAdminRoku = new BLL.Servicios();
        }

        public Servicios CreateServicios(Model.Servicios servicio)
        {
            throw new NotImplementedException();
        }

        public List<Model.Servicios> GetServicios(bool? onlyActive)
        {
            List<Model.Servicios> response = oBussinessAdminRoku.GetServicios(onlyActive);
            return response;
        }
    }
}
