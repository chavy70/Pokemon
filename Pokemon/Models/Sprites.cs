using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class Sprites
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id_Sprites { get; set; }
		public string? Front_Default { get; set; }
		public string? Front_Shiny { get; set; }
		public string? Front_Female { get; set; }
		public string? Front_Shiny_Female { get; set; }
		public string? Back_Default { get; set; }
		public string? Back_Shiny { get; set; }
		public string? Back_Female { get; set; }
		public string? Back_Shiny_Female { get; set; }
	}	
}
