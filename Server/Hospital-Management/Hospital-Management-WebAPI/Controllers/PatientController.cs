using Entity_Layer.CustomClass;
using Data_Access_Layer.Data;
using Data_Access_Layer.Migrations;
using Model_class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Logic_Layer.InterfaceBLL;

namespace Hospital_Management_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientBLL _BLL;
        public PatientController(IPatientBLL BLL)
        {
            _BLL = BLL;
        }
        [HttpGet]
        public async Task<IActionResult> getAllPatients()
        {
            var data = _BLL.getAllPatients();
            return Ok(data);
        }
        [HttpPost]
        
        public IActionResult addPatient(patientDTO patient)
        {
            _BLL.addPatient(patient);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult appointmentId(int id)
        {
            var data = _BLL.appointmentId(id);
            return Ok(data);
        }
        [HttpPut("{id}")]
        public IActionResult updatePatient(int id, patientDTO patient)
        {
            _BLL.updatePatient(id,patient);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult detailsPatient(int id)
        {
            var data = _BLL.detailsPatient(id);
            return Ok(data);
        }
       
    }
}
