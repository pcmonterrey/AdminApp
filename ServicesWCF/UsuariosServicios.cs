using Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServicesWCF
{
    public class UsuariosServicios : IUsuariosServicios
    {
        private BLL.UsuariosServicios oBussinessUsuariosServicios;
        public UsuariosServicios()
        {
            oBussinessUsuariosServicios = new BLL.UsuariosServicios();
        }
        public Model.UsuariosServicios CreateUsuariosServicios(Model.UsuariosServicios usuarioServicio)
        {
            Model.UsuariosServicios response = oBussinessUsuariosServicios.CreateUsuarioServicio(usuarioServicio);
            return response;
        }

        public List<Model.GetUsuariosServicios> GetUsuariosServicios(bool? onlyActive)
        {
            List<Model.GetUsuariosServicios> response = oBussinessUsuariosServicios.GetUsuariosServicios(onlyActive);
            return response;
        }
        public Model.UsuariosServicios EditUsuariosServicios(Model.UsuariosServicios usuarioServicio)
        {
            Model.UsuariosServicios response = oBussinessUsuariosServicios.EditUsuarioServicio(usuarioServicio);
            return response;
        }

        
    }
}
