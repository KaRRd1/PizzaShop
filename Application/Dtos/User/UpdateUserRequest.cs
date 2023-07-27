using Application.Common.Mappings;
using AutoMapper;

namespace Application.Dtos.User;

public class UpdateUserRequest : IMapWith<Domain.Entities.User>
{
    public string? Name { get; set; }
    public string? Email { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserRequest, Domain.Entities.User>();
    }
}