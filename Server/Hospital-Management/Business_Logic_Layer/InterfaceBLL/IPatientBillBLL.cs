using Entity_Layer.CustomClass;
using Model_class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.InterfaceBLL
{
    public interface IPatientBillBLL
    {
        void addPatientBill(PatientBillDTO patientBill);
        List<PatientBill> searchPatientBill(int id);
    }
}
