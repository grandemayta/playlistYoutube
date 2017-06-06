using System;
using Microsoft.EntityFrameworkCore;

namespace PlaylistYoutube.Models
{
    public class PlaylistContext : DbContext
    {
        public PlaylistContext(DbContextOptions<PlaylistContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
    }
}