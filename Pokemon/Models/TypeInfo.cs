using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class TypeInfo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_TypeInfo { get; set; }
		public int? Slot { get; set; }
		public Type Type { get; set; }
		// Foreign Key
		public int? Id_Pokemons { get; set; }

		[ForeignKey("Id_Pokemons")]
		public Pokemons Pokemons { get; set; }
	}
}
