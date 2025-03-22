using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Models;

using Pokemon.Servicios;

namespace Pokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicioAPI _servicioAPI;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IServicioAPI servicioAPI)//(ILogger<HomeController> logger)
        {
            //_logger = logger;
            _servicioAPI = servicioAPI;
        }

		//[HttpGet]
		public async Task<IActionResult> Index(string buscar)
        {
            if(buscar == null) return View();
            ViewBag.Accion = "Buscar Pokemon";
            Pokemons pk = await _servicioAPI.Obtener(buscar); // ("1");
            return View(pk);
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
