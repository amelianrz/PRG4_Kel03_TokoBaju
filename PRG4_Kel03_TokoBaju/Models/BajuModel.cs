using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PRG4_Kel03_TokoBaju.Models
{
    public class BajuModel
    {
        [Required(ErrorMessage = "ID Baju Harus diisi")]
        public string id { get; set; }

        [Required(ErrorMessage = "Nama Baju Wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Nama Baju maksimal 50 Huruf")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nama Baju hanya boleh berisi huruf.")]
        public string nama { get; set; }

        [Required(ErrorMessage = "ID Jenis Baju Harus ada.")]
        public string idjenis { get; set; }

        [Required(ErrorMessage = "Harga Wajib diisi.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Harga hanya boleh berisi angka.")]
        public double harga { get; set; }

        [Required(ErrorMessage = "Ukuran Baju wajib diisi.")]
        public string ukuran { get; set; }

        [Required(ErrorMessage = "Stok Wajib diisi.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Stok hanya boleh berisi angka.")]
        public int stok { get; set; }
    }
}
