using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlaylistYoutube.Models;
using PlaylistYoutube.App_Code.BLL;

namespace PlaylistYoutube.Controllers
{
    [Route("api/v1/[controller]")]
    public class PlaylistController : Controller
    {
        private readonly PlaylistContext _context;
        private PlaylistManager _playlistManager;

        public PlaylistController(PlaylistContext context)
        {
            _context = context;
            _playlistManager = new PlaylistManager(context);
        }

		[HttpGet]
        public IEnumerable<Playlist> GetAll()
        {
            return _playlistManager.GetAll();
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(long id)
        {
            var playlist = _playlistManager.GetById(id);

            if(playlist == null) return NotFound();
            return new ObjectResult(playlist);
        }

		[HttpPost]
        public IActionResult Create([FromBody] Playlist playlist)
        {
            if(ModelState.IsValid) {
                var createPlaylist = _playlistManager.CreatePlaylist(playlist);

                if(createPlaylist == "Created") return CreatedAtRoute("GetById", new { id = playlist.Id }, playlist);
				throw new ArgumentException(createPlaylist);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]Playlist playlist) 
        {
            if (!_playlistManager.Update(id, playlist)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_playlistManager.Delete(id)) return new NoContentResult();
            return NotFound();
        }
    }
}