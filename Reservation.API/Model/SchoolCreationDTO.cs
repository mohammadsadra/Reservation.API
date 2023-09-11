using System.ComponentModel.DataAnnotations;

namespace Reservation.API.Model
{
    public class SchoolCreationDTO
    {
        [Required]
        [MaxLength(50)]
        public string SchoolName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Address { get; set; }
    }
}


