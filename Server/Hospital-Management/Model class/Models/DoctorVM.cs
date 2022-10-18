using System.ComponentModel.DataAnnotations;

namespace Model_class.Models
{
    public class DoctorVM
    {
        [Key]
        public int id { get; set; }
        [Required]
        [RegularExpression(@"\A[^\d_]+\z",ErrorMessage ="Invalid Data Type")]
        public string name { get; set; }
        [Phone]
        public string phnNumber { get; set; }
       
        public string specialist { get; set; }
        public IList<PatientDoctor>patients { get; set; }
    }
}
