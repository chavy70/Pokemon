using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class VersionInfo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id_VersionInfo { get; set; }
		public string? Name { get; set; }
		public string? Url { get; set; }
	}
}
