﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    public class Songs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int song_Id { get; set; }
        public int artist_id { get; set; }
        public string song_name { get; set; }
        public decimal cost { get; set; }
    }
}