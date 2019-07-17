using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Desafio.Models;
using System.Web.Security;


namespace Desafio.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModal _login = new LoginModal();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Logar(string login, string senha)
        {
            var dadoslogin = _login.Login(login, senha);
            if (dadoslogin != null)
            {
                FormsAuthentication.SetAuthCookie(Convert.ToString(dadoslogin.IdLogin), true);
                int idcolaborador = Convert.ToInt32(dadoslogin.IdLogin);

                return RedirectToAction("Index", "Home");

            }
            else

            {
                TempData["usuarioousenhaerrado"] = "login ou Senha invalidos.";
                return RedirectToAction("Index", "Home");

            }
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    } 


}