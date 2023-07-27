using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ShopDbContext _context;

    public UserRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUser(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.SingleOrDefaultAsync(user => user.Id == id, cancellationToken);
        
    }

    public async Task<User?> GetUser(string phone, CancellationToken cancellationToken = default)
    {
        return await _context.Users.SingleOrDefaultAsync(user => user.Phone == phone, cancellationToken);
    }

    public async Task<User> CreateUser(User user, CancellationToken cancellationToken = default)
    {
        var createdUser = _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return createdUser.Entity;
    }

    public async Task<User> UpdateUserInfo(int userId, string? name, string? email, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.SingleAsync(user => user.Id == userId, cancellationToken);
        user.Name = name;
        user.Email = email;
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return user;
    }
}