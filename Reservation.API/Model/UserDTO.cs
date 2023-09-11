using System;
namespace Reservation.API.Model
{
	public class UserDTO
	{
		public Guid Guid { get; set; }

		public string Name { get; set; } = string.Empty;

        public School? School   { get; set; }
        
        public int Role { get; set; }

        public string? PhoneNumber { get; set; }

        public string? EmailAddress { get; set; }
	}
}

