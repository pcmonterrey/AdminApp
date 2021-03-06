﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IServicios
    {
        List<Model.Servicios> GetServicios(bool? onlyActive);
        Model.Servicios CreateServicio(Model.Servicios servicio);
        Model.Servicios EditServicio(Model.Servicios servicio);

    }
}
