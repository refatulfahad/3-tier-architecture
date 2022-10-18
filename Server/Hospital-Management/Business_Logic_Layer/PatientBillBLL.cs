using Business_Logic_Layer.InterfaceBLL;
using Data_Access_Layer.Data;
using Data_Access_Layer.InterfaceDAL;
using Entity_Layer.CustomClass;
using Model_class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class PatientBillBLL: IPatientBillBLL
    {
        private readonly IPatientBillDAL _DAL;
        public PatientBillBLL(IPatientBillDAL DAL)
        {
            _DAL = DAL;   
        }
        public void  addPatientBill(PatientBillDTO patientBill)
        {
            _DAL.addPatientBill(patientBill);
        }
        public List<PatientBill> searchPatientBill(int id)
        {
            var data = _DAL.searchPatientBill(id);
            return data;
        }
    }
}
