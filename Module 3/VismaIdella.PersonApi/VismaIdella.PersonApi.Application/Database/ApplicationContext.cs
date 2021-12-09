using Microsoft.EntityFrameworkCore;
using VismaIdella.PersonApi.Application.Domain;

namespace VismaIdella.PersonApi.Application.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<TodoList> Lists { get; set; }
        public DbSet<TodoListItem> ListItem { get; set; }
    }
}
