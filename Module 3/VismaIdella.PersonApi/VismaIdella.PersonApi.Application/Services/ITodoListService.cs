using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VismaIdella.PersonApi.Application.Domain;

namespace VismaIdella.PersonApi.Application.Services
{
    public interface ITodoListService
    {
        Task<List<TodoList>> GetAsync(CancellationToken cancellationToken = default);
        Task<TodoList> GetAsync(int todoListId, CancellationToken cancellationToken = default);
        Task<List<TodoList>> GetByPersonAsync(int personId, CancellationToken cancellationToken = default);

        Task<TodoList> CreateAsync(TodoList list, CancellationToken cancellationToken = default);
        Task<TodoList> UpdateAsync(TodoList list, CancellationToken cancellationToken = default);
        Task DeleteAsync(int todoListId, CancellationToken cancellationToken = default);

        Task<TodoListItem> CreateItemAsync(TodoListItem item, CancellationToken cancellationToken = default);
        Task<TodoListItem> UpdateItemAsync(TodoListItem item, CancellationToken cancellationToken = default);
        Task DeleteItemAsync(int todoListItemId, CancellationToken cancellationToken = default);
    }
}
