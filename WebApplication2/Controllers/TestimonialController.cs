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
    public class TestimonialsController : ControllerBase
    {
        private ITestmonialsRepository _homeRepo;

        public TestimonialsController(ITestmonialsRepository home)
        {

            _homeRepo = home;
        }
        [HttpPost]
        public async Task<ActionResult<Testimonials>> AddSlider(Testimonials user)
        {
            TryValidateModel(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _homeRepo.AddTestimonials(user);
                return Created("Success", result);
            }
        }
        //update experience
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider([FromBody] Testimonials user, [FromRoute] int id)
        {
            await _homeRepo.UpdateTestimonials(id, user);
            return Ok();
        }
        //delete experience
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var item = await _homeRepo.GetTestimonials(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                await _homeRepo.DeleteTestimonials(id);
                return NoContent();
            }
        }
        //get single experience
        [HttpGet("{id}")]
        public async Task<ActionResult<Testimonials>> GetExp(int id)
        {
            var item = await _homeRepo.GetTestimonials(id);
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
        public ActionResult<List<Testimonials>> GetAll()
        {
            return Ok(_homeRepo.GetAll());
        }
    }
}
