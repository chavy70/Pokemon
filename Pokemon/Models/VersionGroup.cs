using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class VersionGroup
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_VersionGroup { get; set; }
		public string? Name { get; set; }
		public string? Url { get; set; }
		// Foreign Key
		public int? Id_VersionGroupDetail { get; set; }

		[ForeignKey("Id_VersionGroupDetail")]
		public VersionGroupDetail VersionGroupDetail { get; set; }
	}
}
