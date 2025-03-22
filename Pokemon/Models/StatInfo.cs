using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class StatInfo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_StatInfo { get; set; }
		public int? Base_Stat { get; set; }
		public int? Effort { get; set; }
		public Stat Stat { get; set; }
		// Foreign Key
		public int? Id_Pokemons { get; set; }

		[ForeignKey("Id_Pokemons")]
		public Pokemons Pokemons { get; set; }
	}
}
