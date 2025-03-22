using System.Reflection;

namespace Pokemon.Models
{
	public class Pokemons
	{
		/*public string abilities { get; set; }
		public string base_experience { get; set; }
		public string cries { get; set; }
		public string forms { get; set; }
		public string game_indices { get; set; }
		public string height { get; set; }
		public string held_items { get; set; }
		public string id { get; set; }
		public string is_default { get; set; }
		public string location_area_encounters { get; set; }
		public string moves { get; set; }
		public string name { get; set; }
		public string order { get; set; }
		public string past_abilities { get; set; }
		public string past_types { get; set; }
		public string species { get; set; }
		public string sprites { get; set; }
		public string stats { get; set; }
		public string types { get; set; }
		public string weight { get; set; }*/
		public int Id { get; set; }
		public string Name { get; set; }
		public int Base_Experience { get; set; }
		public int Height { get; set; }
		public bool Is_Default { get; set; }
		public int Order { get; set; }
		public int Weight { get; set; }
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
