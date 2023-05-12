using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet İkon Linki Giriniz...")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz...")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı En Fazla 100 Karakter Olabilir..")]
        public string ServiceTitle { get; set; }

        [Required(ErrorMessage = "Hizmet Açıklama Giriniz...")]
        [StringLength(500, ErrorMessage = "Hizmet Başlığı En Fazla 500 Karakter Olabilir..")]
        public string ServiceDescription { get; set; }
    }
}
