using System.ComponentModel.DataAnnotations;

namespace PRG4_Kel03_TokoBaju.Models
{
    public class PembelianModel
    {
        [Required(ErrorMessage = "ID Pembelian wajib diisi.")]
        [MaxLength(5, ErrorMessage = "ID Maksimal 5 karakter.")]
        public string id_trs { get; set; }

        [Required(ErrorMessage = "ID Baju wajib diisi.")]
        [MaxLength(5, ErrorMessage = "ID Maksimal 5 karakter.")]
        public string id { get; set; }

        [Required(ErrorMessage = "Jumlah wajib diisi.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Jumlah hanya boleh berisi angka.")]
        public int jumlah { get; set; }

        [Required(ErrorMessage = "Tanggal wajib diisi.")]
        public DateTime tanggal { get; set; }

        [Required(ErrorMessage = "Total wajib diisi.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Jumlah hanya boleh berisi angka.")]
        public double total { get; set; }

        public BajuModel Baju { get; set; }
    }
}
