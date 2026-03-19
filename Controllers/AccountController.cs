using System.Web.Mvc;
using TuProyecto.Models;

namespace TuProyecto.Controllers
{
    public class AccountController : Controller
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();

        public ActionResult Login()
        {
            return View();
        }

   
        [HttpPost]
        public ActionResult Login(Usuario model)
        {
            if (usuarioDAL.ValidarUsuario(model.Username, model.Password))
            {
                Session["Usuario"] = model.Username; // 🔥 guardar sesión
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

    }
}