using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class Ability
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_Ability { get; set; }
		public string? Name { get; set; }
		public string? Url { get; set; }
		// Foreign Key
		public int? Id_AbilityInfo { get; set; }

		[ForeignKey("Id_AbilityInfo")]
		public AbilityInfo AbilityInfo { get; set; }
	}
}