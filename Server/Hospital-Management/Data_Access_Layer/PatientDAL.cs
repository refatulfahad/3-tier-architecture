using Data_Access_Layer.Data;
using Data_Access_Layer.Migrations;
using Entity_Layer.CustomClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_class.Models;
using Data_Access_Layer.InterfaceDAL;

namespace Data_Access_Layer
{
    public class PatientDAL : IPatientDAL
    {
        private readonly ApplicationDbContext applicationDbContext;
        public PatientDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public List<Patient> getAllPatients()
        {
            var data = applicationDbContext.tbl_Patients.ToList();
            return data;
        }
        public void addPatient(patientDTO patient)
        {
            Patient data = new Patient
            {
                name = patient.name,
                gender = patient.gender,
                age = patient.age,
                phnNumber = patient.phnNumber,

            };
            applicationDbContext.tbl_Patients.Add(data);
            applicationDbContext.SaveChanges();
            foreach (var id in patient.doctorId)
            {
                PatientDoctor pd = new PatientDoctor
                {
                    DoctorId = id,
                    PatientId = data.id,
                };

                applicationDbContext.tbl_PatientDoctor.Add(pd);
                applicationDbContext.SaveChanges();
                //data.doctors.Add(pd);
            }
        }
        public List<int> appointmentId(int id)
        {
            var data = (from a in applicationDbContext.tbl_PatientDoctor
                        where a.PatientId == id
                        select a.DoctorId).ToList();
            return data;
        }
        public void updatePatient(int id, patientDTO patient)
        {
            var data = applicationDbContext.tbl_Patients.FirstOrDefault(x => x.id == id);
            if (patient.name != null) { data.name = patient.name; }
            if (patient.gender != null) { data.gender = patient.gender; }
            if (patient.phnNumber != null) { data.phnNumber = patient.phnNumber; }
            if (patient.age != 0) { data.age = patient.age; }
            //applicationDbContext.tbl_Patients.Update(data);
            applicationDbContext.SaveChanges();
            if (patient.doctorId != null)
            {
                while (true)
                {
                    var list = (from a in applicationDbContext.tbl_PatientDoctor
                                where a.PatientId == id
                                select a).FirstOrDefault();
                    if (list == null) break;
                    applicationDbContext.tbl_PatientDoctor.Remove(list);
                    applicationDbContext.SaveChanges();
                }
                foreach (var Id in patient.doctorId)
                {
                    PatientDoctor pd = new PatientDoctor
                    {
                        DoctorId = Id,
                        PatientId = id,
                    };

                    applicationDbContext.tbl_PatientDoctor.Add(pd);
                    applicationDbContext.SaveChanges();
                }
            }
        }

        public dynamic detailsPatient(int id)
        {

            var data = (from a in applicationDbContext.tbl_PatientDoctor
                        from b in applicationDbContext.tbl_Doctors
                        where a.PatientId == id && a.DoctorId == b.id
                        select new
                        {
                            id = b.id,
                            name = b.name,
                            phnNumber = b.phnNumber,
                            specialist = b.specialist,
                            PatientId = a.PatientId
                        }).ToList();
            return data;
        }
        

    }
}
