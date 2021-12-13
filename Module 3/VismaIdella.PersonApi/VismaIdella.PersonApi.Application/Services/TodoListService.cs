using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VismaIdella.PersonApi.Application.Database;
using VismaIdella.PersonApi.Application.Domain;
using VismaIdella.PersonApi.Application.Exceptions;

namespace VismaIdella.PersonApi.Application.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationContext _context;

        public TodoListService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<TodoList> CreateAsync(TodoList list, CancellationToken cancellationToken = default)
        {
            var person = await _context.Persons
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == list.PersonId, cancellationToken);

            if (person == null)
            {
                throw new EntityNotFoundException(typeof(Person), list.PersonId);
            }

            var duplicate = await _context.Lists
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Name == list.Name, cancellationToken);

            if (duplicate != null)
            {
                throw new EntityConflictException(typeof(TodoList));
            }

            list.DateCreated = DateTime.UtcNow;
            await _context.Lists.AddAsync(list, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return list;
        }

        public async Task<TodoListItem> CreateItemAsync(TodoListItem item, CancellationToken cancellationToken = default)
        {
            var list = await _context.Lists
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == item.TodoListId, cancellationToken);

            if (list == null)
            {
                throw new EntityNotFoundException(typeof(TodoList), item.TodoListId);
            }

            await _context.ListItems.AddAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return item;
        }

        public async Task DeleteAsync(int todoListId, bool deleteItems = true, CancellationToken cancellationToken = default)
        {
            var list = await _context.Lists
                .Include(x => x.Items)
                .SingleOrDefaultAsync(x => x.Id == todoListId, cancellationToken);

            if (list == null)
            {
                throw new EntityNotFoundException(typeof(TodoList), todoListId);
            }

            if (deleteItems)
            {
                foreach (var item in list.Items)
                {
                    _context.ListItems.Remove(item);
                }
            }
            else
            {
                if (list.Items.Count > 0)
                {
                    throw new EntityConflictException(typeof(TodoList), typeof(TodoListItem));
                }
            }

            _context.Lists.Remove(list);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteItemAsync(int todoListId, int todoListItemId, CancellationToken cancellationToken = default)
        {
            var item = await _context.ListItems
                .SingleOrDefaultAsync(x => x.Id == todoListItemId, cancellationToken);

            if (item == null)
            {
                throw new EntityNotFoundException(typeof(TodoListItem), item.Id);
            }

            if (todoListId != item.TodoListId)
            {
                throw new EntityConflictException(typeof(TodoList), typeof(TodoListItem), todoListItemId);
            }

            _context.ListItems.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<TodoList>> GetAsync(
            Expression<Func<TodoList, bool>> predicate = null,
            bool includeItems = false,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Lists
               .AsNoTracking()
               .Cacheable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeItems)
            {
                query = query.Include(x => x.Items);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<TodoList> GetAsync(int todoListId, CancellationToken cancellationToken = default)
        {
            var list = await _context.Lists
                .Include(x => x.Items)
                .Cacheable()
                .SingleOrDefaultAsync(x => x.Id == todoListId, cancellationToken);

            if (list == null)
            {
                throw new EntityNotFoundException(typeof(TodoList), todoListId);
            }

            return list;
        }

        public Task<List<TodoList>> GetByPersonAsync(int personId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TodoList> UpdateAsync(TodoList list, CancellationToken cancellationToken = default)
        {
            var listToUpdate = await _context.Lists
                .Include(x => x.Items)
                .SingleOrDefaultAsync(x => x.Id == list.Id, cancellationToken);

            if (listToUpdate == null)
            {
                throw new EntityNotFoundException(typeof(TodoList), list.Id);
            }

            var duplicate = await _context.Lists
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Name == list.Name && x.Id != list.Id, cancellationToken);

            if (duplicate != null)
            {
                throw new EntityConflictException(typeof(TodoList));
            }

            listToUpdate.Name = list.Name;
            _context.Lists.Update(listToUpdate);
            await _context.SaveChangesAsync(cancellationToken);
            _context.Entry(listToUpdate).State = EntityState.Detached;
            return listToUpdate;
        }

        public async Task<TodoListItem> UpdateItemAsync(TodoListItem item, CancellationToken cancellationToken = default)
        {
            var itemToUpdate = await _context.ListItems
                .SingleOrDefaultAsync(x => x.Id == item.Id, cancellationToken);

            if (itemToUpdate == null)
            {
                throw new EntityNotFoundException(typeof(TodoListItem), item.Id);
            }

            if (itemToUpdate.TodoListId != item.TodoListId)
            {
                throw new EntityConflictException(typeof(TodoList), typeof(TodoListItem), item.Id);
            }

            itemToUpdate.Name = item.Name;
            itemToUpdate.Description = item.Description;
            itemToUpdate.DueDate = item.DueDate;

            _context.ListItems.Update(itemToUpdate);
            await _context.SaveChangesAsync(cancellationToken);
            return item;
        }
    }
}
