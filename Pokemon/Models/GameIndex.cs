using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class GameIndex
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_GameIndex { get; set; }
		public int? Game_Index { get; set; }
		public VersionInfo Version { get; set; }
		// Foreign Key
		public int? Id_Pokemons { get; set; }

		[ForeignKey("Id_Pokemons")]
		public Pokemons Pokemons { get; set; }
	}
}
