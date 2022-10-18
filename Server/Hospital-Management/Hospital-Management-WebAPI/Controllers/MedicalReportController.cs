using Entity_Layer.CustomClass;
using Data_Access_Layer.Data;
using Data_Access_Layer.Migrations;
using Model_class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Logic_Layer.InterfaceBLL;

namespace Hospital_Management_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalReportController : ControllerBase
    {
        private readonly IMedicalReportBLL _BLL;
        public MedicalReportController(IMedicalReportBLL BLL)
        {
            _BLL = BLL;
        }
        [HttpPost]
        public IActionResult addMedicalReport(MedicalReportDTO medicalReport)
        {
            _BLL.addMedicalReport(medicalReport);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult searchMedicalReport(int id)
        {
            var data = _BLL.searchMedicalReport(id);
            return Ok(data);
        }
    }
}