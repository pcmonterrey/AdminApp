using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUsuarios
    {
        List<Model.Usuarios> GetUsuarios(bool? onlyActive);

        
        Model.Usuarios CreateUsuario(Model.Usuarios usuario);
        Model.Usuarios EditUsuario(Model.Usuarios usuario);
    }
}
