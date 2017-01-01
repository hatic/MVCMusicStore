using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCMusicStore_Hatice.Models
{
    [Bind(Exclude = "AlbumId")]
    public class Album
    {
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }
        [DisplayName("Albüm Kategori")]
        public int GenreId { get; set; }
        [DisplayName("Sanatçı")]
        public int ArtistId { set; get; }
        [Required(ErrorMessage = "Albüm adı gereklidir")]
        [StringLength(160)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Fiyat alanı boş geçilemez")]
        [Range(0.01, 100.00,
        ErrorMessage = "Fiyat 0.01 ve 100.00 aralığında olmalı")]
        public decimal Price { get; set; }
        [DisplayName("Albüm URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
