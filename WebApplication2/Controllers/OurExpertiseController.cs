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
    public class OurExpertiseController : ControllerBase
    {
        private IOurExpertiseRepository _homeRepo;

        public OurExpertiseController(IOurExpertiseRepository home)
        {

            _homeRepo = home;
        }
        [HttpPost]
        public async Task<ActionResult<OurExpertise>> AddSlider(OurExpertise user)
        {
            TryValidateModel(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _homeRepo.AddOurExpertise(user);
                return Created("Success", result);
            }
        }
        //update experience
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider([FromBody] OurExpertise user, [FromRoute] int id)
        {
            await _homeRepo.UpdateOurExpertise(id, user);
            return Ok();
        }
        //delete experience
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var item = await _homeRepo.GetOurExpertise(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                await _homeRepo.DeleteOurExpertise(id);
                return NoContent();
            }
        }
        //get single experience
        [HttpGet("{id}")]
        public async Task<ActionResult<OurExpertise>> GetExp(int id)
        {
            var item = await _homeRepo.GetOurExpertise(id);
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
        public ActionResult<List<OurExpertise>> GetAll()
        {
            return Ok(_homeRepo.GetAll());
        }
    }
}
