using AdminRoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminRoku.Controllers
{
    public class BaseController : Controller
    {        
        public ServicesWCF.Servicios oServicios;
        public ServicesWCF.Usuarios oUsuarios;
        public BaseController(){
            oServicios = new ServicesWCF.Servicios();
            oUsuarios = new ServicesWCF.Usuarios();
        }
    }
}