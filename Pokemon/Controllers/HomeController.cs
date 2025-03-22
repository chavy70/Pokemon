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
			ViewBag.Accion = "Buscar Pokemon";
			// Obtener los datos de la PokeAPI
			IServicioAPI _servicioAPI = new ServicioAPI();
            // Si no se busco nada aun no se hace nada
            if (buscar == null) return View();
			// Pregunta en la base de datos local si el pokemon existe
			Pokemons pk = await _context.Pokemons.FirstOrDefaultAsync(p => p.Name == buscar || p.Id.ToString() == buscar);

            
            // Llamar a la PokeAPI
            if (pk is null)
            {
                // Busco el Pokemon desde PokeAPI
                pk = await _servicioAPI.Obtener(buscar);
                if (pk is not null) { 
                    // Agrego al conexto
                    _context.Pokemons.Add(pk);
                    // Guardo en la base de datos local
                    await _context.SaveChangesAsync();
				}else return View();
			}
            else // Llamar a los datos desde la DB local
            {
				pk = _context.Pokemons
		       .Include(p => p.Abilities)//.ThenInclude(a => a.Ability)
               .Include(p=> p.Forms) 
               .Include(p => p.Game_Indices)//.ThenInclude(a => a.Version)
               .Include(p => p.Moves)//.ThenInclude(a=> a.Move)
               .Include(p => p.Stats)//.ThenInclude(a=>a.Stat)
               .Include(p => p.Sprites)
               .Include(p => p.Types)//.ThenInclude(a=>a.Type) // Carga las habilidades relacionadas con el Pok�mon
		       .FirstOrDefault(p => p.Id == pk.Id);
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
