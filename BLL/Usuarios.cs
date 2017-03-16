using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class Usuarios :Base, IUsuarios
    {
        private string _connectionString;
        public Usuarios()
        {
            _connectionString = connectionString;
        }
        public List<Model.Usuarios> GetUsuarios(bool? onlyActive)
        {
            throw new NotImplementedException();
        }
    }
}
