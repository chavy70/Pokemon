using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class MoveInfo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_MoveInfo { get; set; }
		public Move Move { get; set; }
		public List<VersionGroupDetail> Version_Group_Details { get; set; }
		// Foreign Key
		public int? Id_Pokemons { get; set; }

		[ForeignKey("Id_Pokemons")]
		public Pokemons Pokemons { get; set; }
	}
}
