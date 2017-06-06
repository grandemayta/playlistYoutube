using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaylistYoutube.Models;

namespace PlaylistYoutube.Controllers
{
    [Route("api/[controller]")]
    public class SongController : Controller
    {
        private readonly PlaylistContext _context;

        public SongController(PlaylistContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Song> GetAll()
        {
            return _context.Songs.ToList();
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(long id) 
        {
            var item = _context.Songs.FirstOrDefault(current => current.Id == id);
            if(item == null) {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Song song)
        {
            if(song  == null) {
                return BadRequest();
            }

            _context.Songs.Add(song);
            _context.SaveChanges();

            return CreatedAtRoute("GetById", new { id = song.Id}, song);
        }

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var song = _context.Songs.First(current => current.Id == id);
			if (song == null)
			{
				return NotFound();
			}

			_context.Songs.Remove(song);
			_context.SaveChanges();

			return new NoContentResult();
		}
    }
}