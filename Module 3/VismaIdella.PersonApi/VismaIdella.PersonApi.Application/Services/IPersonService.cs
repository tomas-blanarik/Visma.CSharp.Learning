using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VismaIdella.PersonApi.Application.Domain;

namespace VismaIdella.PersonApi.Application.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetAsync(CancellationToken cancellationToken = default);
        Task<Person> GetAsync(int personId, CancellationToken cancellationToken = default);

        Task<Person> CreateAsync(Person person, CancellationToken cancellationToken = default);
        Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken = default);
        Task DeleteAsync(int personId, bool deleteLists = true, CancellationToken cancellationToken = default);
    }
}
