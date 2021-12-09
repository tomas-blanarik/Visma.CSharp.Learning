using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace VismaIdella.PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ListsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("{listId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] int listId,
            CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync(CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPut("{listId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] int listId,
            CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpDelete("{listId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int listId,
            CancellationToken cancellationToken)
        {
            return Ok();
        }

        #region Item Operations

        [HttpPost("{listId:int}/items")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateItemAsync(
            [FromRoute] int listId,
            CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPut("{listId:int}/items/{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateItemAsync(
            [FromRoute] int listId,
            [FromRoute] int itemId,
            CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpDelete("{listId:int}/items/{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> DeleteItemAsync(
            [FromRoute] int listId,
            [FromRoute] int itemId,
            CancellationToken cancellationToken)
        {
            return Ok();
        }

        #endregion

        /*
        List for Person
        - ?? get lists with items ?? [internal] GET /api/lists
        - get list info with items GET /api/lists/{listId}
        - create list (name, personId, date [auto]) POST /api/lists
        - update list (name, listId) PUT /api/lists/{listId}
        - delete list - listId, deleteItems? = true DELETE /api/lists/{listId} 
        - create item in the list (name, listId, date?, description?) POST /api/lists/{listId}/items
        - update item in the list (name, itemId, date?, description?) PUT /api/lists/{listId}/items/{itemId}
        - delete item in the list (itemId) DELETE /api/lists/{listId}/items/{itemId}
        */
    }
}
