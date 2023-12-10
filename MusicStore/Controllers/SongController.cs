using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class SongController : Controller
    {
        private readonly MusicContext _Context;
        public SongController(MusicContext context)
        {
            this._Context = context;
        }
        public IActionResult Index()
        {
            var songs = _Context.songs.ToList();
            List<SongView> songList = new List<SongView>();
            if (songs != null)
            {
                
                foreach (var song in songs)
                {
                    var SongView = new SongView()
                    {
                        song_Id = song.song_Id,
                        artist_id = song.artist_id,
                        song_name = song.song_name,
                        cost = song.cost
                    };
                    songList.Add(SongView);
                }
                return View(songList);
            }
            return View(songList);
        }
    }
}
