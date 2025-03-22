using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Pokemon.Models
{
	public class Pokemons
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_Pokemons { get; set; }
		public int? Id { get; set; }
		public string? Name { get; set; }
		public int? Base_Experience { get; set; }
		public int? Height { get; set; }
		public bool? Is_Default { get; set; }
		public int? Order { get; set; }
		public int? Weight { get; set; }
		public List<AbilityInfo> Abilities { get; set; }
		public List<Form> Forms { get; set; }
		public List<GameIndex> Game_Indices { get; set; }
		public List<MoveInfo> Moves { get; set; }
		public Sprites Sprites { get; set; }
		public Species Species { get; set; }
		public List<StatInfo> Stats { get; set; }
		public List<TypeInfo> Types { get; set; }
	}
}
