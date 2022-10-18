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
    public class MedicalReportBLL: IMedicalReportBLL
    {
        private readonly IMedicalReportDAL _DAL;
        public MedicalReportBLL(IMedicalReportDAL DAL)
        {
            _DAL = DAL;
        }
        
        public void addMedicalReport(MedicalReportDTO medicalReport)
        {
            _DAL.addMedicalReport(medicalReport);
        }
        public List<MedicalReport> searchMedicalReport(int id)
        {
            var data = _DAL.searchMedicalReport(id);
            return data;
        }
    }
}
