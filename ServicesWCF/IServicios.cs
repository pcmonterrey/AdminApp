using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicios
    {
        [OperationContract]
        List<Model.Servicios> GetServicios(bool? onlyActive);

        [OperationContract]
        Model.Servicios CreateServicios(Model.Servicios servicio);

        [OperationContract]
        Model.Servicios EditServicios(Model.Servicios servicio);

    }
}
