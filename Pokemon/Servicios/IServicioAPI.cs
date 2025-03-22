using Pokemon.Models;
namespace Pokemon.Servicios
{
	public interface IServicioAPI
	{
		Task<Pokemons> Obtener(string pokemon);
	}
}
