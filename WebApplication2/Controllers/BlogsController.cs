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
    public class BlogsController : ControllerBase
    {
        private IBlogsRepository _homeRepo;

        public BlogsController(IBlogsRepository home)
        {

            _homeRepo = home;
        }
        [HttpPost]
        public async Task<ActionResult<Blogs>> AddSlider(Blogs user)
        {
            TryValidateModel(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _homeRepo.AddBlogs(user);
                return Created("Success", result);
            }
        }
        //update experience
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider([FromBody] Blogs user, [FromRoute] int id)
        {
            await _homeRepo.UpdateBlogs(id, user);
            return Ok();
        }
        //delete experience
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var item = await _homeRepo.GetBlogs(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                await _homeRepo.DeleteBlogs(id);
                return NoContent();
            }
        }
        //get single experience
        [HttpGet("{id}")]
        public async Task<ActionResult<Blogs>> GetExp(int id)
        {
            var item = await _homeRepo.GetBlogs(id);
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
        public ActionResult<List<Blogs>> GetAll()
        {
            return Ok(_homeRepo.GetAll());
        }
    }
}
