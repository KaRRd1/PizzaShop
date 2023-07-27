using Application.Dtos.User;

namespace Application.Interfaces.Services;

public interface IUserService
{
    public Task<UserResponse> CreateUser(LoginUserRequest request, CancellationToken cancellationToken = default);
    public Task<UserResponse?> GetUser(int id,CancellationToken cancellationToken = default);
    public Task<UserResponse?> GetUser(string phone,CancellationToken cancellationToken = default);
    public Task<UserResponse> GetOrCreateUser(LoginUserRequest request, CancellationToken cancellationToken = default);
    public Task<UserResponse> UpdateUser(int userId, UpdateUserRequest request, CancellationToken cancellationToken = default);
}