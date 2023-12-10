namespace MusicStore.Models
{
    public class SongView
    {
        public int song_Id { get; set; }
        public int artist_id { get; set; }
        public string song_name { get; set; }
        public decimal cost { get; set; }
    }
}
