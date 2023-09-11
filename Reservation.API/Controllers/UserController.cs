using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservation.API.Model;
using Reservation.API.Repositories;

namespace Reservation.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public UserController(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _reservationRepository.GetUsersAsync();
            Console.WriteLine("_________________________");
            Console.WriteLine(users.First().Name);
            Console.WriteLine("_________________________");

            try
            {
                return Ok(
                    _mapper.Map<IEnumerable<UserDTO>>(users)
                ); 
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("{guid}")]
        [Produces("application/json")]
        public async Task<ActionResult<UserDTO>> GetUserById(Guid guid)
        {
            try
            {
                var user = await _reservationRepository.GetSchoolById(guid);
                Console.WriteLine("_________________________");
                Console.WriteLine(user.Name);
                Console.WriteLine("_________________________");
                return Ok(
                    _mapper.Map<UserDTO>(user)
                ); 
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
