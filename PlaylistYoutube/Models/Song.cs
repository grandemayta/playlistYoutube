using System;

namespace PlaylistYoutube.Models
{
    public class Song
    {
        public long Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public enum Genre { Rock, Pop, Salsa, Cumbia, Bachata, Reggeaton }
    }
}