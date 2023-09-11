using System;
namespace Reservation.API.Model
{
	public class SchoolDTO
	{
        public int Id { get; set; }

        public string SchoolName { get; set; } = string.Empty;

        public string? Address { get; set; }
    }
}

