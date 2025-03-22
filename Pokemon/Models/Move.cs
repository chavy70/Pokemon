using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class Move
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_Move { get; set; }
		public string? Name { get; set; }
		public string? Url { get; set; }
		// Foreign Key
		public int? Id_MoveInfo { get; set; }

		[ForeignKey("Id_MoveInfo")]
		public MoveInfo MoveInfo { get; set; }
	}
}
