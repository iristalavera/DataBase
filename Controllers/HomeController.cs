using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReporteVentas.Models;
using System.Diagnostics;

namespace ReporteVentas.Controllers
{
    public class HomeController : Controller
    {
        private readonly VentaTiendaContext _context;

        public HomeController(VentaTiendaContext context)
        {
            _context = context;
        }

        //accion para recuperar informacion de las ventas en retropecstiva de tres meses

        public IActionResult MostrarVentas()
        {
            return StatusCode(Status);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
