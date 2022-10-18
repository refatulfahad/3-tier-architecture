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
    public class MedicalReportDAL: IMedicalReportDAL
    {
        private readonly ApplicationDbContext applicationDbContext;
        public MedicalReportDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        
        public void addMedicalReport(MedicalReportDTO medicalReport)
        {
            var data = new MedicalReport
            {
                patientProblem = medicalReport.patientProblem,
                medicalTest = medicalReport.medicalTest,
                medicalResult = medicalReport.medicalResult,
                date = medicalReport.date,
                patientId = medicalReport.patientId,
            };
            applicationDbContext.tbl_medicalReports.Add(data);
            applicationDbContext.SaveChanges();
        }
        public List<MedicalReport> searchMedicalReport(int id)
        {
            var data = (from a in applicationDbContext.tbl_medicalReports
                        where a.patientId == id
                        select a).ToList();
            return data;
        }
    }
}
