using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaylistYoutube.Models;

namespace PlaylistYoutube.Controllers
{
    [Route("api/v1/[controller]")]
    public class PlaylistController : Controller
    {
        private readonly PlaylistContext _context;

        public PlaylistController(PlaylistContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Playlist> GetAll()
        {
            var videos = (from p in _context.Playlists
                          select new Playlist {
                            Name = p.Name,
                            Videos = p.Videos.ToList()
                         }).ToList();

            return videos;
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(long id)
        {
            var playlist = _context.Playlists.FirstOrDefault(current => current.Id == id);
            if(playlist == null) {
                return NotFound();
            }
            return new ObjectResult(playlist);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Playlist playlist)
        {
            if(!ModelState.IsValid) {
                return BadRequest();
            }

            _context.Playlists.Add(playlist);
            _context.SaveChanges();

            return CreatedAtRoute("GetById", new { id = playlist.Id }, playlist);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var playlist = _context.Playlists.First(current => current.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playlist);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}