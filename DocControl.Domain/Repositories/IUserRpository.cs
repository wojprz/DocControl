using DocControl.Domain.Entities;

namespace DocControl.Domain.Repositories
{
    public interface IUserRpository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string login);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetAllAsync(int page, int count = 10);
        Task RemoveAsync(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task UpdateStatusAsync(Guid id, int status);
        Task UpdateRoleAsync(Guid id, int role);
    }
}
