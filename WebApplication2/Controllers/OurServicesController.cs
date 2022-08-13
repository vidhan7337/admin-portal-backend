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
    public class OurServicesController : ControllerBase
    {
        private IOurServicesRepository _homeRepo;

        public OurServicesController(IOurServicesRepository home)
        {

            _homeRepo = home;
        }
        [HttpPost]
        public async Task<ActionResult<OurServices>> AddSlider(OurServices user)
        {
            TryValidateModel(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _homeRepo.AddOurServices(user);
                return Created("Success", result);
            }
        }
        //update experience
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider([FromBody] OurServices user, [FromRoute] int id)
        {
            await _homeRepo.UpdateOurServices(id, user);
            return Ok();
        }
        //delete experience
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var item = await _homeRepo.GetOurServices(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                await _homeRepo.DeleteOurServices(id);
                return NoContent();
            }
        }
        //get single experience
        [HttpGet("{id}")]
        public async Task<ActionResult<OurServices>> GetExp(int id)
        {
            var item = await _homeRepo.GetOurServices(id);
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
        public ActionResult<List<OurServices>> GetAll()
        {
            return Ok(_homeRepo.GetAll());
        }
    }
}
