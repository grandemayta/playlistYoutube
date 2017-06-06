using System;
using System.Collections.Generic;

namespace PlaylistYoutube.Models
{
    public class Playlist
    {
        public Playlist() {
            this.Videos = new List<Video>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public List<Video> Videos { get; set; }
        public enum Genre { Rock, Pop, Salsa, Cumbia, Bachata, Reggeaton }
    }
}
