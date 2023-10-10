using System.ComponentModel.DataAnnotations;

namespace PRG4_Kel03_TokoBaju.Models
{
    public class JenisModel
    {
        [Required(ErrorMessage = "ID wajib diisi.")]
        [MaxLength(5, ErrorMessage = "Penulis maksimal 5 Karakter")]
        public string id { get; set; }
        [Required(ErrorMessage = "Nama wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Judul maksimal 30 Karakter")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Penulis hanya boleh berisi huruf.")]
        public string nama { get; set; }

    }
}
