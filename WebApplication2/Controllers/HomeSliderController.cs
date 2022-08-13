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
    public class HomeSliderController : ControllerBase
    {
        private IHomeSliderRepository _homeRepo;

        public HomeSliderController(IHomeSliderRepository home)
        {

            _homeRepo = home;
        }
        [HttpPost]
        public async Task<ActionResult<HomeSlider>> AddSlider(HomeSlider user)
        {
            TryValidateModel(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _homeRepo.AddHomeSlider(user);
                return Created("Success", result);
            }
        }
        //update experience
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider([FromBody] HomeSlider user, [FromRoute] int id)
        {
            await _homeRepo.UpdateHomeSlider(id, user);
            return Ok();
        }
        //delete experience
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var item = await _homeRepo.GetHomeSlider(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                await _homeRepo.DeleteHomeSlider(id);
                return NoContent();
            }
        }
        //get single experience
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeSlider>> GetExp(int id)
        {
            var item = await _homeRepo.GetHomeSlider(id);
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
        public ActionResult<List<HomeSlider>> GetAll()
        {
            return Ok(_homeRepo.GetAll());
        }
    }
}
