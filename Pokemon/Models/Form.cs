using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class Form
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_Form { get; set; }
		public string? Name { get; set; }
		public string? Url { get; set; }
		// Foreign Key
		public int? Id_Pokemons { get; set; }

		[ForeignKey("Id_Pokemons")]
		public Pokemons Pokemons { get; set; }
	}
}
