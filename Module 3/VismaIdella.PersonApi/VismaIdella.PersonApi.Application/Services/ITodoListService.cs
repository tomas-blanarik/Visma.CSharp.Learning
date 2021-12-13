using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VismaIdella.PersonApi.Application.Domain;

namespace VismaIdella.PersonApi.Application.Services
{
    public interface ITodoListService
    {
        Task<List<TodoList>> GetAsync(
            Expression<Func<TodoList, bool>> predicate = null,
            bool includeItems = false,
            CancellationToken cancellationToken = default);
        Task<TodoList> GetAsync(int todoListId, CancellationToken cancellationToken = default);
        //Task<List<TodoList>> GetByPersonAsync(int personId, CancellationToken cancellationToken = default);

        Task<TodoList> CreateAsync(TodoList list, CancellationToken cancellationToken = default);
        Task<TodoList> UpdateAsync(TodoList list, CancellationToken cancellationToken = default);
        Task DeleteAsync(int todoListId, bool deleteItems = true, CancellationToken cancellationToken = default);

        Task<TodoListItem> CreateItemAsync(TodoListItem item, CancellationToken cancellationToken = default);
        Task<TodoListItem> UpdateItemAsync(TodoListItem item, CancellationToken cancellationToken = default);
        Task DeleteItemAsync(int todoListId, int todoListItemId, CancellationToken cancellationToken = default);
    }
}
