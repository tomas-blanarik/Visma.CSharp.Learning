using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VismaIdella.PersonApi.Application.Dtos;
using VismaIdella.PersonApi.Application.Models;
using VismaIdella.PersonApi.Application.Services;

namespace VismaIdella.PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PersonDto>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var persons = await _personService.GetAsync(cancellationToken);
            var personDtos = persons.ConvertAll(x => x.ToDto());
            return Ok(personDtos);
        }

        [HttpGet("{personId:int}", Name = "GetPerson")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] int personId,
            CancellationToken cancellationToken = default)
        {
            var person = await _personService.GetAsync(personId, cancellationToken);
            return Ok(person.ToDto());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync(
            [FromBody, Bind] CreatePersonModel model,
            CancellationToken cancellationToken)
        {
            var person = model.ToDomain();
            person = await _personService.CreateAsync(person, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, person.ToDto());
        }

        [HttpPut("{personId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] int personId,
            [FromBody, Bind] UpdatePersonModel model,
            CancellationToken cancellationToken)
        {
            var person = model.ToDomain();
            person.Id = personId;
            person = await _personService.UpdateAsync(person, cancellationToken);
            return Ok(person.ToDto());
        }

        [HttpDelete("{personId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int personId,
            CancellationToken cancellationToken,
            [FromQuery] bool deleteLists = true)
        {
            await _personService.DeleteAsync(personId, deleteLists, cancellationToken);
            return Ok();
        }

        #region List Operations

        [HttpGet("{personId:int}/lists")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TodoListDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListsAsync(
            [FromRoute] int personId,
            [FromServices] ITodoListService listService,
            CancellationToken cancellationToken)
        {
            var lists = await listService.GetAsync(x => x.PersonId == personId, includeItems: true, cancellationToken);
            return Ok(lists.ConvertAll(x => x.ToDto()));
        }

        #endregion

        /*
        Person API
        - create (name, email, address?) POST /api/persons
        - update (name, email, personId, address?) PUT /api/persons/{personId}
        - get all persons GET /api/persons
        - get person (personId) GET /api/persons/{personId}
        - delete person (personId) DELETE /api/persons/{personId}
        - get my lists (personId) GET /api/persons/{personId}/lists
        */
    }
}
