using Microsoft.AspNetCore.Mvc;
using MVCBilleteraVirtual.Models;
using System.Diagnostics;

namespace MVCBilleteraVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Tarjetas = DatabaseHelper.DatabaseHelper.GetTarjetas();

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarTarjeta(string txtIDTarjeta, string txtDueño, string selectBanco, string selectEmisor, string txtNumeroTarjeta, string txtCodigoCVV, string txtFechaExpiracion)
        {

            Tarjetas tarjetas = new Tarjetas()
            {
                Dueño = txtDueño,
                Banco = selectBanco,
                Emisor = selectEmisor,
                NumeroTarjeta = txtNumeroTarjeta,
                CodigoCVV = txtCodigoCVV,
                FechaExpiracion = txtFechaExpiracion,
                FotoBanco = "/images/" + selectBanco + ".jpg",
                FotoEmisor = "/images/"+ selectEmisor + ".jpg"
            };

            DatabaseHelper.DatabaseHelper.AgregarTarjeta(tarjetas);

            return RedirectToAction("Index", "Home");
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