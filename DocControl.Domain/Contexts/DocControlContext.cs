using DocControl.Domain.Entities;
using DocControl.Domain.settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;

namespace DocControl.Domain.Contexts
{
    public class DocControlContext : DbContext
    {
        private readonly IOptions<SqlSettings> _settings;
        public DocControlContext(DbContextOptions<DocControlContext> options, IOptions<SqlSettings> sqlSettings) : base(options)
        {
            _settings = sqlSettings;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.Value.ConnectionString,
               options =>
               {
                   options.MigrationsAssembly("PixBlocks_Addition.Api");
               });
        }
    }
}
