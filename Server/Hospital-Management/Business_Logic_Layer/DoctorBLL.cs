
using Data_Access_Layer;
using Data_Access_Layer.InterfaceDAL;
using Data_Access_Layer.Data;
using Business_Logic_Layer.InterfaceBLL;
using Data_Access_Layer.Migrations;
using Model_class.Models;
using Entity_Layer.CustomClass;

namespace Business_Logic_Layer
{
    public class DoctorBLL: IDoctorBLL
    {
        private readonly IDoctorDAL _DAL;
        public DoctorBLL(IDoctorDAL DAL)
        {
            _DAL = DAL;
        }
        public List<DoctorVM> GetDoctorList()
        {
            return _DAL.GetDoctorList();
        }
        public void AddDoctor(DoctorDTO doctor)
        {
            _DAL.AddDoctor(doctor);
        }
 
        public void UpdateDoctor(int id, DoctorDTO doctor)
        {
            _DAL.UpdateDoctor(id, doctor);
        }

       
        public void DeleteDoctor(int id)
        {
            _DAL.DeleteDoctor(id);
        }
    }
}