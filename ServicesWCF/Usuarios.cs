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
        public Model.Usuarios CreateUsuarios(Model.Usuarios usuario)
        {
            throw new NotImplementedException();
        }

        public List<Model.Usuarios> GetUsuarios(bool? onlyActive)
        {
            throw new NotImplementedException();
        }
    }
}
