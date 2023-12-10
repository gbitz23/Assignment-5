using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicStore.Models
{
    public class SongView
    {
        public List<Songs>? song { get; set; }
        public SelectList? genre_list { get; set; }
        public SelectList? artist_list { get; set; }
        public string? genre_name { get; set; }
        public string? artist_name { get; set; }
    }
}
