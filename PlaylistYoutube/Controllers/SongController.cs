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

        public SongController(PlaylistContext context) {
            _context = context;

            if(_context.Songs.Count() == 0) {
                _context.Songs.Add(new Song { Name = "Vamos a bailar", Url = "http://fake.com/22893939" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Song> GetAll() {
            return _context.Songs.ToList();
        }
    }
}