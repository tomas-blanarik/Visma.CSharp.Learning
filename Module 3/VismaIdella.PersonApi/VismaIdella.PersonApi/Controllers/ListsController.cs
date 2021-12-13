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
    public class ListsController : ControllerBase
    {
        private readonly ITodoListService _listService;

        public ListsController(ITodoListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TodoListLightDto>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var lists = await _listService.GetAsync(cancellationToken: cancellationToken);
            return Ok(lists.ConvertAll(x => x.ToLightDto()));
        }

        [HttpGet("{listId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoListDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] int listId,
            CancellationToken cancellationToken)
        {
            var list = await _listService.GetAsync(listId, cancellationToken);
            return Ok(list.ToDto());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TodoListDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync(
            [FromBody, Bind] CreateTodoListModel model,
            CancellationToken cancellationToken)
        {
            var list = await _listService.CreateAsync(model.ToDomain(), cancellationToken);
            return StatusCode(StatusCodes.Status201Created, list.ToDto());
        }

        [HttpPut("{listId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoListDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] int listId,
            [FromBody, Bind] UpdateTodoListModel model,
            CancellationToken cancellationToken)
        {
            var list = model.ToDomain();
            list.Id = listId;
            list = await _listService.UpdateAsync(list, cancellationToken);
            return Ok(list.ToDto());
        }

        [HttpDelete("{listId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int listId,
            CancellationToken cancellationToken,
            [FromQuery] bool deleteItems = true)
        {
            await _listService.DeleteAsync(listId, deleteItems, cancellationToken);
            return Ok();
        }

        #region Item Operations

        [HttpPost("{listId:int}/items")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TodoListItemDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateItemAsync(
            [FromRoute] int listId,
            [FromBody, Bind] CreateTodoListItemModel model,
            CancellationToken cancellationToken)
        {
            var item = model.ToDomain();
            item.TodoListId = listId;
            item = await _listService.CreateItemAsync(item, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, item.ToDto());
        }

        [HttpPut("{listId:int}/items/{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoListItemDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateItemAsync(
            [FromRoute] int listId,
            [FromRoute] int itemId,
            [FromBody, Bind] UpdateTodoListItemModel model,
            CancellationToken cancellationToken)
        {
            var item = model.ToDomain();
            item.Id = itemId;
            item.TodoListId = listId;
            item = await _listService.UpdateItemAsync(item, cancellationToken);
            return Ok(item.ToDto());
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
            await _listService.DeleteItemAsync(listId, itemId, cancellationToken);
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
