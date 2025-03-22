using Pokemon.Models;
namespace Pokemon.Servicios
{
	public interface IServicioAPI
	{
		// Interface para obtener datos de la API
		Task<Pokemons> Obtener(string pokemon);
	}
}
