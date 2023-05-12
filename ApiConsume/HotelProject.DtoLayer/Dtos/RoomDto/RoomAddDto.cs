using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage ="Lütfen Oda Numarasını Yazınız...")]
        public string RoomNumber { get; set; }

        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen Fiyat Bilgisini Yazınız...")]
        public int RoomPrice { get; set; }

        [Required(ErrorMessage = "Lütfen Oda Başlığını Yazınız...")]
        public string RoomTitle { get; set; }

        [Required(ErrorMessage = "Lütfen Yatak Sayısını Yazınız...")]
        public string RoomBedCount { get; set; }

        [Required(ErrorMessage = "Lütfen Banyo Sayısını Yazınız...")]
        public string RoomBathCount { get; set; }

        public string RoomWifi { get; set; }
        public string RoomDescription { get; set; }
    }
}
