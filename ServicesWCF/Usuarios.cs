using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ServicesWCF
{
    public class Usuarios : IUsuarios
    {
        private BLL.Usuarios oBussinessUsuarios;
        public Usuarios()
        {
            oBussinessUsuarios = new BLL.Usuarios();
        }
        public Model.Usuarios CreateUsuarios(Model.Usuarios usuario)
        {
            Model.Usuarios response = oBussinessUsuarios.CreateUsuario(usuario);
            return response;
        }

        public List<Model.Usuarios> GetUsuarios(bool? onlyActive)
        {
            List<Model.Usuarios> response = oBussinessUsuarios.GetUsuarios(onlyActive);
            return response;
        }
        public Model.Usuarios EditUsuarios(Model.Usuarios usuario)
        {
            Model.Usuarios response = oBussinessUsuarios.EditUsuario(usuario);
            return response;
        }

    }
}
