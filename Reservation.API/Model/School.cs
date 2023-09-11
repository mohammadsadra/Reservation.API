using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservation.API.Model
{
	public class School
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }

		[Required]
		public string Name { get; set; }

		[MaxLength(200)]
		public string? Address { get; set; }

		// Relation
		[ForeignKey("UserGuid")]
		public User? Manger { get; set; }
		public Guid UserGuid { get; set; }



	}
}

