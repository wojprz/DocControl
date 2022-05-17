using DocControl.Domain.Contexts;
using DocControl.Domain.Entities;

namespace DocControl.Domain.Repositories
{
    public class UserRepository : IUserRpository
    {
        private readonly DocControlContext _entities;
        public UserRepository(DocControlContext entities)
        {
            _entities = entities;
        }

        public async Task AddAsync(User user)
        {
            await _entities.Users.AddAsync(user);
            await _entities.SaveChangesAsync();
        }

        public async Task<User> GetAsync(Guid id) => await _entities.Users.SingleOrDefault(x => x.Id == id);
    }
}
