using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Models;
using Pokemon.Servicios;
using Xunit;

namespace Pokemon.Tests
{
	public class UnitTest1 
	{
		[Fact]
		public async Task Test1()
		{
			
			// Creo una base de datos en memoria
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(databaseName: "Pokemons")
				.Options;

			using var context = new ApplicationDbContext(options);
			IServicioAPI _servicioAPI = new ServicioAPI();


			// PRUEBA #1  -------------------------------------------------------------------------------
			Pokemons pk = await context.Pokemons.FirstOrDefaultAsync(p => p.Name == "bulbasaur" || p.Id.ToString() == "1");
			if (pk is null)
			{
				// Busco el Pokemon desde PokeAPI
				pk = await _servicioAPI.Obtener("bulbasaur");
				// Agrego al contexto
				context.Pokemons.Add(pk);
				// Guardo en la base de datos local
				await context.SaveChangesAsync();
			}
			var result = await context.Pokemons.FirstOrDefaultAsync(p => p.Name == "bulbasaur" || p.Id.ToString() == "-9");
			// Assert
			Assert.NotNull(result);
			Assert.Equal("bulbasaur", result.Name);




			// PRUEBA #2  -------------------------------------------------------------------------------
			pk = await context.Pokemons.FirstOrDefaultAsync(p => p.Name == "bulbasaur" || p.Id.ToString() == "1");
			if (pk is null)
			{
				// Busco el Pokemon desde PokeAPI
				pk = await _servicioAPI.Obtener("bulbasaur");
				// Agrego al contexto
				context.Pokemons.Add(pk);
				// Guardo en la base de datos local
				await context.SaveChangesAsync();
			}
			result = await context.Pokemons.FirstOrDefaultAsync(p => p.Name == "bulbasaur" || p.Id.ToString() == "-9");
			// Assert
			Assert.NotNull(result);
			Assert.Equal("bulbasaur", result.Name);





			// PRUEBA #3  -------------------------------------------------------------------------------
			pk = await context.Pokemons.FirstOrDefaultAsync(p => p.Name == "A" || p.Id.ToString() == "4");
			if (pk is null)
			{
				// Busco el Pokemon desde PokeAPI
				pk = await _servicioAPI.Obtener("4");
				// Agrego al contexto
				context.Pokemons.Add(pk);
				// Guardo en la base de datos local
				await context.SaveChangesAsync();
			}
			result = await context.Pokemons.FirstOrDefaultAsync(p => p.Name == "charmander" || p.Id.ToString() == "-9");
			// Assert
			Assert.NotNull(result);
			Assert.Equal("charmander", result.Name);



			// PRUEBA #4  -------------------------------------------------------------------------------
			pk = await context.Pokemons.FirstOrDefaultAsync(p => p.Name == "A" || p.Id.ToString() == "0");
			if (pk is null)
			{
				// Busco el Pokemon desde PokeAPI
				pk = await _servicioAPI.Obtener("0");
				// Agrego al contexto
				context.Pokemons.Add(pk);
				// Guardo en la base de datos local
				await context.SaveChangesAsync();
			}
			result = await context.Pokemons.FirstOrDefaultAsync(p => p.Name == "a" || p.Id.ToString() == "0");
			// Assert
			Assert.NotNull(result);
			Assert.Equal("charmander", result.Name);
		}
	}
}
