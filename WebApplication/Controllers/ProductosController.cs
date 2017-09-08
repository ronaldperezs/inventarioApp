using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            return View();
        }

        public ActionResult Eliminar(int id)
        {
            return View();
        }
    }
}