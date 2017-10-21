using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TrabrajoPracticoGrupo10;

namespace TrabajoPracticoGrupo10.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            if (ViewData["sessionString"] != null)
            {
                return View();
            }
            else
            {
                ViewData["sessionString"] = null;
            }

            return View();
        }

        //Registrar usuario, creo un modelo vacío
        public ActionResult Registro()
        {
            Usuario modelUsuario = new Usuario();
            return View(modelUsuario);
        }

        public ActionResult Registro_Correcto()
        {

            return View();
        }

        public ActionResult Mostrar_usuarios()
        {
            EntitiesTurismo ctx = new EntitiesTurismo();
            List<Usuario> lista = ctx.Usuarios.ToList();
            /*List<Usuario> listafinal = new List<Usuario>();
            foreach (var usuario in lista)
            {
                if (usuario.Nombre == "karen")
                { listafinal.Add(usuario); }
            }
            return View(listafinal);*/
            return View(lista);
        }

        public ActionResult Eliminar(int id)
        {

            id = Convert.ToInt32(RouteData.Values["id"]);

            EntitiesTurismo ctx = new EntitiesTurismo();
            List<Usuario> lista = ctx.Usuarios.ToList();
            
            foreach (var usuario in lista)
            {
                if (usuario.Id == id)
                { ctx.Usuarios.Remove(usuario); }
            }
            ctx.SaveChanges();

            return RedirectToAction("Mostrar_usuarios", "Home");
        }

        public ActionResult ModificarUsuario(int id)
        {

            id = Convert.ToInt32(RouteData.Values["id"]);//recivo el id pasado por parametro

            EntitiesTurismo ctx = new EntitiesTurismo(); //crea la entidad de la DB
            List<Usuario> lista = ctx.Usuarios.ToList(); //crea una lista de usuarios de la tabla usuarios
            Usuario usuarioModificar = new Usuario();//crea un usuario vacio

            foreach (var usuario in lista)//empiezo a recorrer la lista de usaurios de la DB
            {
                if (usuario.Id == id)//comparo si el id del parametro es igual al del usuario
                { usuarioModificar = usuario; }//igualo el usuario vacio con el usaurio del id
            }
           


            return View(usuarioModificar);//devuelvo la vista con los datos del usaurio
        }

        [HttpPost]
        public ActionResult ModificarUsuario(Usuario u)
        {

            m(u);
            
            return RedirectToAction("Mostrar_usuarios", "Home");

        }

        public void m(Usuario u)
        {
            EntitiesTurismo ctx = new EntitiesTurismo(); //crea la entidad de la DB
            Usuario p = ctx.Usuarios.FirstOrDefault(r => r.Id == u.Id);
            p.Nombre=u.Nombre;
            p.Apellido = u.Apellido;
            p.Contrasenia = u.Contrasenia;
            p.Email = u.Email;
            ctx.SaveChanges();
        }

        public ActionResult Iniciar_Sesion()
        {
            return View();
        }

        //Valido que los campos del registro sean correctos
        [HttpPost]
        public ActionResult Autenticar(Usuario u)        //VALIDACION DEL FORMULARIO DE REGISTRO
        {
            EntitiesTurismo ctx = new EntitiesTurismo();

            if (ModelState.IsValid)                       //SIRVE PARA VERIFICAR SI TODAS LAS REGLAS DE VALIDACION FUERON CUMPLIDAS
            {
                ctx.Usuarios.Add(u);
                ctx.SaveChanges();
                return RedirectToAction("Registro_Correcto", "Home"); //SI EL MODELO ES VALIDO, RETORNA ESTA VISTA
            }

            return View("Registro", u);                   //SI EL MODELO NO ES VALIDO, RETORNA ESTA VISTA
        }

        [HttpPost]
        public ActionResult AutenticarModificar(Usuario u)        //VALIDACION DEL FORMULARIO DE REGISTRO
        {
            EntitiesTurismo ctx = new EntitiesTurismo();

            if (ModelState.IsValid)                       //SIRVE PARA VERIFICAR SI TODAS LAS REGLAS DE VALIDACION FUERON CUMPLIDAS
            {
                ctx.Usuarios.Add(u);
                ctx.SaveChanges();
                return RedirectToAction("Mostrar_usuarios", "Home"); //SI EL MODELO ES VALIDO, RETORNA ESTA VISTA
            }

            return View("Modificar", u);                   //SI EL MODELO NO ES VALIDO, RETORNA ESTA VISTA
        }

        [HttpPost]
        public ActionResult Autenticar_Iniciar_Sesion(Usuario u)        //VERIFICA EL INICIO DE SESIÓN
        {

            if (u.Email != null)
            {
                HttpCookie c = new HttpCookie("Email");  //COOKIE
                c.Value = u.Email;
                Response.Cookies.Add(c);

                return RedirectToAction("Index");
            }
            return View("Iniciar_Sesion", u);
        }
        
        public ActionResult Cerrar_Sesion()        //VERIFICA EL INICIO DE SESIÓN
        {
            Response.Cookies["Email"].Value = "";
            Response.Cookies["Email"].Expires = DateTime.Now;

            return View("Index");
        }

        public ActionResult Crear_Paquete()
        {
            
            return View("Crear_Paquete");
        }

        [HttpPost]
        public ActionResult Crear_Paquete(Paquete p)
        {
            if (ModelState.IsValid)                       //SIRVE PARA VERIFICAR SI TODAS LAS REGLAS DE VALIDACION FUERON CUMPLIDAS
            {
                return RedirectToAction("Listado_Paquetes", "Home");
            }
            return View("Crear_Paquete");
        }

    }
}