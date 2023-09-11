using System;
using Microsoft.EntityFrameworkCore;
using Reservation.API.DbContexts;
using Reservation.API.Model;

namespace Reservation.API.Repositories
{
    public class ReservationRepository : IReservationRepository
	{
        private readonly ReservationDbContext _context;

        public ReservationRepository(ReservationDbContext context)
        {
            _context  = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.OrderBy(u => u.Name).ToListAsync();
        }

        public async Task<User?> GetUserById(Guid guid)
        {
            var temp = await _context.Users.OrderBy(u => u.Name).ToListAsync();
            foreach (var user in temp)
            {
                Console.WriteLine(user.Name);
                if (user.Guid == guid)
                {
                    return user;
                }
            }

            return null;
            // return await _context.Users.Where(u => u.Guid.ToString().ToUpper().Equals(guid.ToString().ToUpper())).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<School>> GetSchools()
        {
            return await _context.Schools.OrderBy(s => s.Name).ToListAsync();
        }

        public async Task<School?> GetSchoolById(Guid guid)
        {
            return await _context.Schools.Where(s => s.Guid == guid).FirstOrDefaultAsync();
        }
    }
}

