using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUser(int id, CancellationToken cancellationToken = default);
    public Task<User?> GetUser(string phone, CancellationToken cancellationToken = default);
    public Task<User> CreateUser(User user, CancellationToken cancellationToken = default);
    public Task<User> UpdateUserInfo(int userId, string? name, string? email, CancellationToken cancellationToken = default);
}