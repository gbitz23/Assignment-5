using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class SongController : Controller
    {
        private readonly MusicContext _Context;
        public SongController(MusicContext context)
        {
            _Context = context;
        }

        //Fill song table based on form load and unselected values
        public async Task<IActionResult> Index(string musicGenre, string musicPerformer)
        {
            if (_Context.songs == null)
            {
                return Problem("Music Database Context is a null value.");
            }

            IQueryable<string> genreQuery = from x in _Context.songs
                                            orderby x.genre_name
                                            select x.genre_name;

            IQueryable<string> performerQuery = from x in _Context.songs
                                                orderby x.artist_name
                                                select x.artist_name;

            var music = from x in _Context.songs
                        select x;

            if (!string.IsNullOrEmpty(musicGenre))
            {
                music = music.Where(x => x.genre_name == musicGenre);

                performerQuery = from x in _Context.songs
                                 where x.genre_name == musicGenre
                                 orderby x.genre_name
                                 select x.artist_name;
            }

            if (!string.IsNullOrEmpty(musicPerformer))
            {
                music = music.Where(x => x.artist_name == musicPerformer);
            }

            var view = new SongView
            {
                genre_list = new SelectList(await genreQuery.Distinct().ToListAsync()),
                artist_list = new SelectList(await performerQuery.Distinct().ToListAsync()),
                song = await music.ToListAsync()
            };
            
            return View(view);
        }

        /*//Fill table based on filters
        public async Task<IActionResult> filter(string musicGenre, string musicPerformer)
        {
            if (_Context.songs == null)
            {
                return Problem("Music Database Context is a null value.");
            }

            IQueryable<string> genreQuery = from x in _Context.songs
                                            orderby x.genre_name
                                            select x.genre_name;

            IQueryable<string> performerQuery = from x in _Context.songs
                                                orderby x.artist_name
                                                select x.artist_name;


            var music = from x in _Context.songs
                        select x;

            if (!string.IsNullOrEmpty(musicGenre))
            {
                music = music.Where(x => x.genre_name == musicGenre);
                performerQuery = from x in _Context.songs
                                 where x.genre_name == musicGenre
                                 orderby x.artist_name
                                 select x.artist_name;
            }

            if (!string.IsNullOrEmpty(musicPerformer))
            {
                music = music.Where(x => x.artist_name == musicPerformer);
            }

            var view = new SongView
            {
                genre_list = new SelectList(await genreQuery.Distinct().ToListAsync()),
                artist_list = new SelectList(await performerQuery.Distinct().ToListAsync()),
                song = await music.ToListAsync()
            };

            return View(view);
        }*/
    }
}
