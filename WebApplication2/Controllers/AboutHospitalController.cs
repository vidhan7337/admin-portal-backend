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
    public class AboutHospitalController : ControllerBase
    {
        private IAboutHospitalRepository _homeRepo;

        public AboutHospitalController(IAboutHospitalRepository home)
        {

            _homeRepo = home;
        }
        [HttpPost]
        public async Task<ActionResult<AboutHospital>> AddSlider(AboutHospital user)
        {
            TryValidateModel(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _homeRepo.AddAboutHospital(user);
                return Created("Success", result);
            }
        }
        //update experience
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider([FromBody] AboutHospital user, [FromRoute] int id)
        {
            await _homeRepo.UpdateAboutHospital(id, user);
            return Ok();
        }
        //delete experience
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var item = await _homeRepo.GetAboutHospital(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                await _homeRepo.DeleteAboutHospital(id);
                return NoContent();
            }
        }
        //get single experience
        [HttpGet("{id}")]
        public async Task<ActionResult<AboutHospital>> GetExp(int id)
        {
            var item = await _homeRepo.GetAboutHospital(id);
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
        public ActionResult<List<AboutHospital>> GetAll()
        {
            return Ok(_homeRepo.GetAll());
        }
    }
}
