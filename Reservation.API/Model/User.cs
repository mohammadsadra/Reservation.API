using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservation.API.Model
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Guid { get; set; }

		[Required]
        [MaxLength(100)]
        public string Name { get; set; }

		[Required]
		public int Role { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(60)]
        public string? EmailAddress { get; set; }
        
        
        public School? School { get; set; }
        

        public User(string name)
		{
			this.Name = name;
		}
	}
}

