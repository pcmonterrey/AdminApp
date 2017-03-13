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
        public BLL.AdminRoku oBussiness;
        public BaseController(){
            oBussiness = new BLL.AdminRoku();
        }
    }
}