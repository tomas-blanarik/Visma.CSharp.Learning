using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VismaIdella.PersonApi.Application.Database;
using VismaIdella.PersonApi.Application.Domain;
using VismaIdella.PersonApi.Application.Exceptions;

namespace VismaIdella.PersonApi.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationContext _context;

        public PersonService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Person> CreateAsync(Person person, CancellationToken cancellationToken = default)
        {
            var duplicate = await _context.Persons
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email == person.Email, cancellationToken);

            if (duplicate != null)
            {
                throw new EntityConflictException(typeof(Person));
            }

            await _context.Persons.AddAsync(person, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return person;
        }

        public async Task DeleteAsync(int personId, bool deleteLists = true, CancellationToken cancellationToken = default)
        {
            var person = await _context.Persons
                .SingleOrDefaultAsync(x => x.Id == personId, cancellationToken);

            if (person == null)
            {
                throw new EntityNotFoundException(typeof(Person), personId);
            }

            var personLists = await _context.Lists
                .Where(x => x.PersonId == person.Id)
                .ToListAsync(cancellationToken);

            if (deleteLists)
            {
                personLists.ForEach(list => _context.Lists.Remove(list));
            }
            else
            {
                if (personLists.Count != 0)
                {
                    throw new EntityConflictException(typeof(Person), typeof(TodoList));
                }
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Person>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Persons
                .AsNoTracking()
                .Cacheable()
                .ToListAsync(cancellationToken);
        }

        public async Task<Person> GetAsync(int personId, CancellationToken cancellationToken = default)
        {
            var person = await _context.Persons
                .AsNoTracking()
                .Cacheable()
                .SingleOrDefaultAsync(x => x.Id == personId, cancellationToken);

            if (person == null)
            {
                throw new EntityNotFoundException(typeof(Person), personId);
            }

            return person;
        }

        public async Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken = default)
        {
            var personToUpdate = await _context.Persons
                .SingleOrDefaultAsync(x => x.Id == person.Id, cancellationToken);

            if (person == null)
            {
                throw new EntityNotFoundException(typeof(Person), person.Id);
            }

            var duplicate = await _context.Persons
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email == person.Email && x.Id != person.Id, cancellationToken);

            if (duplicate != null)
            {
                throw new EntityConflictException(typeof(Person));
            }

            personToUpdate.Name = person.Name;
            personToUpdate.Email = person.Email;
            personToUpdate.Address = person.Address;

            _context.Persons.Update(personToUpdate);
            await _context.SaveChangesAsync(cancellationToken);
            _context.Entry(personToUpdate).State = EntityState.Detached;
            return personToUpdate;
        }
    }
}
