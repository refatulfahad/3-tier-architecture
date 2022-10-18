using Data_Access_Layer.Data;
using Data_Access_Layer.InterfaceDAL;
using Entity_Layer.CustomClass;
using Model_class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class PatientBillDAL: IPatientBillDAL
    {
        private readonly ApplicationDbContext applicationDbContext;
        public PatientBillDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void addPatientBill(PatientBillDTO patientBill)
        {
            var data = new PatientBill()
            {
                billType = patientBill.billType,
                billAmount = patientBill.billAmount,
                date = patientBill.date,
                patientId = patientBill.patientId
            };
            applicationDbContext.tbl_PatientBill.Add(data);
            applicationDbContext.SaveChanges();
        }
        public List<PatientBill> searchPatientBill(int id)
        {
            var data = (from a in applicationDbContext.tbl_PatientBill
                        where a.patientId == id
                        select a).ToList();
           
            return data;
        }
    }
}
