using Entity_Layer.CustomClass;
using Model_class.Models;


namespace Business_Logic_Layer.InterfaceBLL
{
    public interface IDoctorBLL
    {
        List<DoctorVM> GetDoctorList();
        void AddDoctor(DoctorDTO doctor);
        void UpdateDoctor(int id, DoctorDTO doctor);

        void DeleteDoctor(int id);
    }
}
