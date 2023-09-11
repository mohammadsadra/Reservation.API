using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;


namespace Reservation.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider fextp;

        public FilesController(FileExtensionContentTypeProvider fextp)
        {
            this.fextp = fextp;
        }


        [HttpGet()]
        public ActionResult GetFile()
        {
            string pathToFile = "/Users/imohammadsadra/Downloads/test.txt";

            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            
            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            if(!fextp.TryGetContentType(pathToFile, out var contentType
                ))
            {
                contentType = "application/octet-stream";
            }
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}

