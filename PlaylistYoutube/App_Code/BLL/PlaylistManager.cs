using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlaylistYoutube.Models;

namespace PlaylistYoutube.App_Code.BLL
{
    public class PlaylistManager
    {
        private readonly PlaylistContext _context;

        public PlaylistManager(PlaylistContext context) 
        {
            _context = context;
        }

        public String CreatePlaylist(Playlist playlist)
        {
            try
            {
                _context.Playlists.Add(playlist);
                _context.SaveChanges();
                return "Created";
            }
            catch(Exception ex) {
                return ex.Message;
            }
        }

        public Boolean Update(long id, Playlist playlist)
        {
            var _playlist = _context.Playlists.FirstOrDefault(x => x.Id == id);
            if (_playlist == null) return false;

            _playlist.Name = playlist.Name;
            _playlist.Videos = playlist.Videos;

            _context.Playlists.Update(_playlist);
            _context.SaveChanges();

            return true;
        }

        public List<Playlist> GetAll() 
        {
            return (from x in _context.Playlists
                    select new Playlist {
                      Id = x.Id,
                      Name = x.Name,
                      Videos = x.Videos.ToList()
                   }).ToList();
        }

        public Playlist GetById(long id)
        {
            return (from x in _context.Playlists
                    where x.Id == id
                    select new Playlist {
                      Id = x.Id,
                      Name = x.Name,
                      Videos = x.Videos.ToList()
                   }).FirstOrDefault();
        }

        public bool Delete(long id)
        {
            var playlist = _context.Playlists.First(x => x.Id == id);
            if (playlist == null) return false;

            _context.Playlists.Remove(playlist);
            _context.SaveChanges();

            return true;
        }
    }
}