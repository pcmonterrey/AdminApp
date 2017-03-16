using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicesWCF
{
    [ServiceContract]
    public interface IUsuarios
    {
        [OperationContract]
        List<Model.Usuarios> GetUsuarios(bool? onlyActive);

        [OperationContract]
        Model.Usuarios CreateUsuarios(Model.Usuarios usuario);
        // TODO: Add your service operations here
    }
}
