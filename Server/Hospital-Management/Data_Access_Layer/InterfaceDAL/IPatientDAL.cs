using Data_Access_Layer.Migrations;
using Entity_Layer.CustomClass;
using Model_class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.InterfaceDAL
{
    public interface IPatientDAL
    {
        List<Patient> getAllPatients();
        void addPatient(patientDTO patient);
        List<int> appointmentId(int id);
        void updatePatient(int id, patientDTO patient);
        dynamic detailsPatient(int id);
    }
}
