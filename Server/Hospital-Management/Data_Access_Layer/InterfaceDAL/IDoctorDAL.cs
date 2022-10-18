using Entity_Layer.CustomClass;
using Model_class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.InterfaceDAL
{
    public interface IDoctorDAL
    {
        List<DoctorVM> GetDoctorList();
        void AddDoctor(DoctorDTO doctor);
        void UpdateDoctor(int id, DoctorDTO doctor);
        void DeleteDoctor(int id);
    }
}
