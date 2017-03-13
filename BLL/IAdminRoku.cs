using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAdminRoku
    {
        List<Servicios> GetServicios(bool? onlyActive);
    }
}
