namespace Model_class.Models
{
    public class PatientDoctor
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public DoctorVM Doctor { get; set; }
    }
}
