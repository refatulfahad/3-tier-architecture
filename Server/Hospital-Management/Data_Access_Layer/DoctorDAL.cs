using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Data;
using Model_class.Models;
using Data_Access_Layer.InterfaceDAL;
using Data_Access_Layer.Migrations;
using Entity_Layer.CustomClass;

namespace Data_Access_Layer
{
    public class DoctorDAL: IDoctorDAL
    {
        private readonly ApplicationDbContext applicationDbContext;


        public DoctorDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public List<DoctorVM> GetDoctorList()
        {

            var res = applicationDbContext.tbl_Doctors.ToList();
            return res;
        }
        public void AddDoctor(DoctorDTO doctor)
        {
            var data = new DoctorVM()
            {
                name = doctor.name,
                phnNumber = doctor.phnNumber,
                specialist = doctor.specialist,
            };
            applicationDbContext.tbl_Doctors.AddAsync(data);
            applicationDbContext.SaveChangesAsync();
            
        }
       
        public void UpdateDoctor(int id, DoctorDTO doctor)
        {

            var data = applicationDbContext.tbl_Doctors.Find(id);

            data.name = doctor.name;
            data.phnNumber = doctor.phnNumber;
            data.specialist = doctor.specialist;

            applicationDbContext.tbl_Doctors.Update(data);
            applicationDbContext.SaveChangesAsync();
        }

        
        public void DeleteDoctor(int id)
        {
            var data = applicationDbContext.tbl_Doctors.Find(id);
            if (data != null)
            {
                applicationDbContext.tbl_Doctors.Remove(data);
                applicationDbContext.SaveChanges();
                
            }

        }
    }
}