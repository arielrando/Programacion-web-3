using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabajoPracticoGrupo10.Controllers
{
    public class MenuController : Controller
    {
        
        public ActionResult _pvMenuAdmin()
        {
            return PartialView();
        }

        public ActionResult _pvMenuUsuario()
        {
            return PartialView();
        }

        public ActionResult _pvMenuAnonimo()
        {
            return PartialView();
        }
    }
}
