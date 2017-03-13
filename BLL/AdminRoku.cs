using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminRoku :IAdminRoku
    {

        public List<Model.Servicios> GetServicios(bool? onlyActive)
        {
            ServicesWCF.ServiceRokuAdmin oSvc = new ServicesWCF.ServiceRokuAdmin();
            List<Model.Servicios> response = oSvc.GetServicios(null);
            return response;
        }
    }
}
