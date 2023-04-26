using Microsoft.AspNetCore.Mvc;
using uploadImage.Data;
using uploadImage.Model;

namespace uploadImage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;

        public UserController(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost]
        public async Task<ActionResult> PostUser(IFormFile file, [FromForm] string email, [FromForm] string fullname)
        {
            // Save the image to disk
            var folderPath = Path.Combine(_environment.ContentRootPath, "images");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var filePath = Path.Combine(folderPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Save the path to the image in the database
            var user = new User
            {
                Email = email,
                Fullname = fullname,
                ImagePath = filePath
            };
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
