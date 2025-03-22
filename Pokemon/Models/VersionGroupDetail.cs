using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
	public class VersionGroupDetail
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_VersionGroupDetail { get; set; }
		public int? Level_Learned_At { get; set; }
		public MoveLearnMethod Move_Learn_Method { get; set; }
		public VersionGroup Version_Group { get; set; }
		// Foreign Key
		public int? Id_MoveInfo { get; set; }

		[ForeignKey("Id_MoveInfo")]
		public MoveInfo MoveInfo { get; set; }
	}
}
