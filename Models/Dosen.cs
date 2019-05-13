using System.ComponentModel.DataAnnotations;
namespace ASPCoreGroupB.Models{
    public class Dosen {

        [Required(ErrorMessage="Data Nik harus diisi")]
        [StringLength(8,MinimumLength=8)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string Nik { get; set; }

        [Required]
        public string Nama { get; set; }

        [Required]
        public string Alamat { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}