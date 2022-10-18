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
    public class PatientBillController : ControllerBase
    {
        private readonly IPatientBillBLL _BLL;
        public PatientBillController(IPatientBillBLL BLL)
        {
            _BLL = BLL;
        }
        [HttpPost]
        public IActionResult addPatientBill(PatientBillDTO patientBill)
        {
            _BLL.addPatientBill(patientBill);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult searchPatientBill(int id)
        {
            var data = _BLL.searchPatientBill(id);
            return Ok(data);
        }
        //[HttpPut("{id}")]
        // public IActionResult updatePatientBill(int id,PatientBill1 patientBill1)
        // {
        //     var data = new PatientBill
        //     {
        //         Id=id,
        //         Bill_Type=patientBill1.Bill_Type,
        //         Bill_Amount=patientBill1.Bill_Amount,
        //         date=patientBill1.date,
        //         PatientId=patientBill1.PatientId
        //     };
        //     applicationDbContext.tbl_PatientBill.Update(data);
        //     applicationDbContext.SaveChanges();
        //     return Ok();
        // }

    }
}
