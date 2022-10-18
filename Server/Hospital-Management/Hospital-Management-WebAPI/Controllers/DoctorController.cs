using Model_class.Models;
using Business_Logic_Layer.InterfaceBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using Entity_Layer.CustomClass;

namespace Hospital_Management_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        //private readonly ApplicationDbContext applicationDbContext;
        //public DoctorController(ApplicationDbContext applicationDbContext)
        //{
        //    this.applicationDbContext = applicationDbContext;
        //}
        private readonly IDoctorBLL _BLL;
        public DoctorController(IDoctorBLL BLL)
        {
            _BLL = BLL;
        }
        [HttpGet]
        public async Task<IActionResult> GetDoctorList()
        {

             var data=_BLL.GetDoctorList();
             return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDTO doctor)
        {

            _BLL.AddDoctor(doctor);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor([FromRoute] int id, DoctorDTO doctor)
        {
            _BLL.UpdateDoctor(id,doctor);            
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            _BLL.DeleteDoctor(id);
            return Ok();
        }
    }
}
