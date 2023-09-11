using System;
using Microsoft.AspNetCore.Mvc;
using Reservation.API.Model;
using Reservation.API.Services;

namespace Reservation.API.Controllers
{
    [Route("api/school")]
    [ApiController]
    public class SchoolController: ControllerBase
	{

        private readonly ILogger<SchoolController> _logger;
        private readonly IMailService _mailService;

        public SchoolController(ILogger<SchoolController> logger, IMailService localMailService)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _mailService = localMailService ?? throw new ArgumentException (nameof(localMailService));
        }


        [HttpGet]
        [Produces("application/json")]  
        public ActionResult<IEnumerable<UserDTO>> GetSchools()
        {
            return Ok(SchoolsDataStore.current.Schools);
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<SchoolDTO> CreatSchool([FromBody] SchoolCreationDTO school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var id = SchoolsDataStore.current.Schools.Max(s => s.Id) + 1;
            _logger.LogInformation($"last id now is: {id}");

          
            var createdSchool = new SchoolDTO()
            {
                Id = id,
                 SchoolName = school.SchoolName,
                Address = school.Address
            };

            SchoolsDataStore.current.Schools.Add(createdSchool);
            Console.Write(SchoolsDataStore.current.Schools.ToString());

            _mailService.Email(subject: $"New School {createdSchool.SchoolName}", htmlString: $"New registery from {createdSchool.SchoolName}.\n Please check dashboard.\n MCI Digital Day Team");
            

            return Ok(createdSchool) ;
        }
	}
}

