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
    public class PrivacyPolicyAndTnCController : ControllerBase
    {
        private IPrivacyPolicyRepository _homeRepo;

        public PrivacyPolicyAndTnCController(IPrivacyPolicyRepository home)
        {

            _homeRepo = home;
        }
        [HttpPost]
        public async Task<ActionResult<PrivacyPolicyAndTnC>> AddSlider(PrivacyPolicyAndTnC user)
        {
            TryValidateModel(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _homeRepo.AddPrivacyPolicyAndTnC(user);
                return Created("Success", result);
            }
        }
        //update experience
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider([FromBody] PrivacyPolicyAndTnC user, [FromRoute] int id)
        {
            await _homeRepo.UpdatePrivacyPolicyAndTnC(id, user);
            return Ok();
        }
        //delete experience
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var item = await _homeRepo.GetPrivacyPolicyAndTnC(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                await _homeRepo.DeletePrivacyPolicyAndTnC(id);
                return NoContent();
            }
        }
        //get single experience
        [HttpGet("{id}")]
        public async Task<ActionResult<PrivacyPolicyAndTnC>> GetExp(int id)
        {
            var item = await _homeRepo.GetPrivacyPolicyAndTnC(id);
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
        public ActionResult<List<PrivacyPolicyAndTnC>> GetAll()
        {
            return Ok(_homeRepo.GetAll());
        }
    }
}
