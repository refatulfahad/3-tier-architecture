using Business_Logic_Layer.InterfaceBLL;
using Data_Access_Layer.Data;
using Data_Access_Layer.InterfaceDAL;
using Data_Access_Layer.Migrations;
using Entity_Layer.CustomClass;
using Model_class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class PatientBLL: IPatientBLL
    {
        private readonly IPatientDAL _DAL;
        public PatientBLL(IPatientDAL DAL)
        {
            _DAL= DAL;
        }
        
        public List<Patient> getAllPatients()
        {
            var data = _DAL.getAllPatients();
            return data;
        }

        public void addPatient(patientDTO patient)
        {
            _DAL.addPatient(patient);
        }
        public List<int> appointmentId(int id)
        {
            var data = _DAL.appointmentId(id);
            return data;
        }
        public void updatePatient(int id, patientDTO patient)
        {
            _DAL.updatePatient(id,patient);
        }

        public dynamic detailsPatient(int id)
        {
            var data = _DAL.detailsPatient(id);
            return data;
        }
    }
}
