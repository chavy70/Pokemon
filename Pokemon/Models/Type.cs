using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class Type
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_Type { get; set; }
		public string? Name { get; set; }
		public string? Url { get; set; }
		// Foreign Key
		public int? Id_TypeInfo { get; set; }

		[ForeignKey("Id_TypeInfo")]
		public TypeInfo TypeInfo { get; set; }
	}
}
