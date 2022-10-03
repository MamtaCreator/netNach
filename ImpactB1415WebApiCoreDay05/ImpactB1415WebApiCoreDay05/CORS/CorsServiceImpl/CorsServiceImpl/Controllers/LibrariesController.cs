using CorsServiceImpl.Entities;
using CorsServiceImpl.Repository.Contract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsServiceImpl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryRepository<Author> _libraryRepository;

        public LibrariesController(ILibraryRepository<Author> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        // GET: api/Libraries/GetAllAuthor  
        [HttpGet]
        [Route("GetAllAuthor")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetAllAuthor()
        {
            IEnumerable<Author> authors = _libraryRepository.GetAllAuthor();
            return Ok(authors);
        }
    }
}
