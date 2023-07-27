using Application.Dtos;
using Application.Dtos.Order;
using Application.Dtos.User;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper, IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<UserResponse> CreateUser(LoginUserRequest request, CancellationToken cancellationToken = default)
    {
        var user = _mapper.Map<User>(request);

        user.RoleId = 2;
        
        var createdUser = await _userRepository.CreateUser(user, cancellationToken);
        var createdUserDto = _mapper.Map<UserResponse>(createdUser);

        return createdUserDto;
    }

    public async Task<UserResponse?> GetUser(int id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUser(id, cancellationToken);
        var userDto = _mapper.Map<UserResponse>(user);

        return userDto;
    }

    public async Task<UserResponse?> GetUser(string phone, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUser(phone, cancellationToken);
        var userDto = _mapper.Map<UserResponse>(user);

        return userDto;
    }

    public async Task<UserResponse> GetOrCreateUser(LoginUserRequest request, CancellationToken cancellationToken = default)
    {
        var userDto = await GetUser(request.Phone, cancellationToken) ??
                      await CreateUser(request, cancellationToken);

        return userDto;
    }

    public async Task<UserResponse> UpdateUser(int userId, UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        var updatedUser = await _userRepository.UpdateUserInfo(userId, request.Name, request.Email, cancellationToken);
        var userDto = _mapper.Map<UserResponse>(updatedUser);

        return userDto;
    }
}