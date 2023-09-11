using Reservation.API.Model;

namespace Reservation.API
{
	public class UsersDataStore
	{
		public List<UserDTO> Users { get; set; }

		public static UsersDataStore current { get; } = new UsersDataStore();

		public UsersDataStore()
		{
			Users = new List<UserDTO>()
			{
            };
		}
	}
}

