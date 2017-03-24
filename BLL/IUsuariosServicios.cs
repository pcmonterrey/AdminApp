﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUsuariosServicios
    {
        List<Model.UsuariosServicios> GetUsuariosServicios(bool? onlyActive);


        Model.UsuariosServicios CreateUsuarioServicio(Model.UsuariosServicios usuarioServicio);
        Model.UsuariosServicios EditUsuarioServicio(Model.UsuariosServicios usuarioServicio);
    }
}
