using Microsoft.AspNetCore.Mvc;
using Notebook.Models;
using Notebook.Repository;

namespace Notebook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {

        private readonly IPersonRepository _personRepository;

        public PersonsController(IPersonRepository context)
        {
            _personRepository = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                var persons = await _personRepository.GetAllAsync();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] Person newPerson)
        {
            try
            {
                await _personRepository.AddAsync(newPerson);
                return Ok(newPerson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            try
            {
                var person = await _personRepository.GetAsync(id);
                if (person == null)
                {
                    return NotFound();
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePerson(Person updatePerson)
        {
            try
            {
                var person = await _personRepository.UpdateAsync(updatePerson);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            try
            {
                int rowsAffected = await _personRepository.RemoveAsync(id);
                return Ok(rowsAffected);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}