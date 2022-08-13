using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentFormController : ControllerBase
    {
        private IAppointmentFormRepository _homeRepo;

        public AppointmentFormController(IAppointmentFormRepository home)
        {

            _homeRepo = home;
        }
        [HttpPost]
        public async Task<ActionResult<AppointmentForm>> AddSlider(AppointmentForm user)
        {
            TryValidateModel(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _homeRepo.AddAppointmentForm(user);
                return Created("Success", result);
            }
        }
        //update experience
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider([FromBody] AppointmentForm user, [FromRoute] int id)
        {
            await _homeRepo.UpdateAppointmentForm(id, user);
            return Ok();
        }
        //delete experience
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var item = await _homeRepo.GetAppointmentForm(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                await _homeRepo.DeleteAppointmentForm(id);
                return NoContent();
            }
        }
        //get single experience
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentForm>> GetExp(int id)
        {
            var item = await _homeRepo.GetAppointmentForm(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }
        [HttpGet]
        public ActionResult<List<AppointmentForm>> GetAll()
        {
            return Ok(_homeRepo.GetAll());
        }

    }
}
