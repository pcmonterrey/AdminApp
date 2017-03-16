using Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ServicesWCF
{    
    public class Servicios : IServicios
    {
        private BLL.Servicios oBussinessServicios;
        public Servicios()
        {
            oBussinessServicios = new BLL.Servicios();
        }

        public Model.Servicios CreateServicios(Model.Servicios servicio)
        {
            Model.Servicios response = oBussinessServicios.CreateServicio(servicio);
            return response;
        }

        public List<Model.Servicios> GetServicios(bool? onlyActive)
        {
            List<Model.Servicios> response = oBussinessServicios.GetServicios(onlyActive);
            return response;
        }
    }
}
