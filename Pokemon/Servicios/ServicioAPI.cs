using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pokemon.Models;
using System.Net.Http.Headers;
using System.Text;

namespace Pokemon.Servicios
{
	public class ServicioAPI : IServicioAPI
	{
		private static string _urlBase;

		/**
		 * Obtengo los datos necesarios
		 * **/
		public ServicioAPI() { 
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
			_urlBase = builder.GetSection("ApiSettings:urlBase").Value;
		}

		/**
		 * Obtener la informacion de un pokemon desde pokeAPI
		 * **/
		public async Task<Pokemons> Obtener(string pokemon)
		{
			var cliente = new HttpClient();
			try { 
				cliente.BaseAddress = new Uri(_urlBase);
				// Solicito la informacion a la API
				var response = await cliente.GetAsync(pokemon);
				if (response.IsSuccessStatusCode)
				{
					var jsonRespuesta = await response.Content.ReadAsStringAsync();
					// Convierto a objeto Pokemon el resultado
					var resultado = JsonConvert.DeserializeObject<Pokemons>(jsonRespuesta);
					return resultado;
				}
				else {
					return null;
				}
			}
			catch (Exception ex) {
				return null;
			}
			throw new NotImplementedException();
		}
	}
}
