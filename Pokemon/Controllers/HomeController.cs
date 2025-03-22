using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Models;

using Pokemon.Servicios;

namespace Pokemon.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IServicioAPI _servicioAPI;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)//(IServicioAPI servicioAPI)//(ILogger<HomeController> logger)
        {
            //_logger = logger;
            //_servicioAPI = servicioAPI;
            _context = context;
        }

        public async Task<IActionResult> Index(string buscar)
        {
            // Obtener los datos de la PokeAPI
            IServicioAPI _servicioAPI = new ServicioAPI();
            // Si no se busco nada aun no se hace nada
            if (buscar == null) return View();
			// Pregunta en la base de datos local si el pokemon existe
			Pokemons pk = await _context.Pokemons.FirstOrDefaultAsync(p => p.Name == buscar || p.Id.ToString() == buscar);

            ViewBag.Accion = "Buscar Pokemon";
            // Llamar a la PokeAPI
            if (pk is null)
            {
                // Busco el Pokemon desde PokeAPI
                pk = await _servicioAPI.Obtener(buscar);
                // Agrego al conexto
                _context.Pokemons.Add(pk);
                // Guardo en la base de datos local
                await _context.SaveChangesAsync();
            }
            else // Llamar a los datos desde la DB local
            { 
            
            }
                //Muestro en pantalla los datos
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
