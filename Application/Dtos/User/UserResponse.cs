using Application.Common.Mappings;
using AutoMapper;

namespace Application.Dtos.User;

public class UserResponse: IMapWith<Domain.Entities.User>
{
    public int Id { get; set; }
    public string Phone { get; set; } = null!;
    public string? Name { get; set; }
    public string? Email { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.User, UserResponse>();
    }
}