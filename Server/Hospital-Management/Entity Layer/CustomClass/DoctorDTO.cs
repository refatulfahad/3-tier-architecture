using System.ComponentModel.DataAnnotations;

namespace Entity_Layer.CustomClass
{
    public class DoctorDTO
    {
        // public int? id { get; set; }
        [StringLength(10,ErrorMessage ="Name is too big")]
        public string? name { get; set; }
        [Phone]
        public string? phnNumber { get; set; }

        public string? specialist { get; set; }
    }
}
