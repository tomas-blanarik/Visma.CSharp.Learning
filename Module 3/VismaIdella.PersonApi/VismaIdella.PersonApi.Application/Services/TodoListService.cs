using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VismaIdella.PersonApi.Application.Database;
using VismaIdella.PersonApi.Application.Domain;

namespace VismaIdella.PersonApi.Application.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationContext _context;

        public TodoListService(ApplicationContext context)
        {
            _context = context;
        }

        public Task<TodoList> CreateAsync(TodoList list, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<TodoListItem> CreateItemAsync(TodoListItem item, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int todoListId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteItemAsync(int todoListItemId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TodoList>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<TodoList> GetAsync(int todoListId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TodoList>> GetByPersonAsync(int personId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<TodoList> UpdateAsync(TodoList list, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<TodoListItem> UpdateItemAsync(TodoListItem item, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
