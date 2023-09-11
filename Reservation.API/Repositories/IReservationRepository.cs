using Reservation.API.Model;

namespace Reservation.API.Repositories
{
	public interface IReservationRepository
	{
		Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserById(Guid guid);

		Task<IEnumerable<School>> GetSchools();
        Task<School?> GetSchoolById(Guid guid);


    }
}

