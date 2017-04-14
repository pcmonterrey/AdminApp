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
    [ServiceContract]
    public interface IUsuariosServicios
    {
        [OperationContract]
        List<Model.GetUsuariosServicios> GetUsuariosServicios(bool? onlyActive);

        [OperationContract]
        Model.UsuariosServicios CreateUsuariosServicios(Model.UsuariosServicios usuarioServicio);

        [OperationContract]
        Model.UsuariosServicios EditUsuariosServicios(Model.UsuariosServicios usuarioServicio);
        // TODO: Add your service operations here
    }
}
