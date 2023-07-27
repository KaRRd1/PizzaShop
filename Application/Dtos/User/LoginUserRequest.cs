using System.ComponentModel.DataAnnotations;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.Dtos.User;

public class LoginUserRequest : IMapWith<Domain.Entities.User>
{
    public string Phone { get; set; } = null!;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<LoginUserRequest, Domain.Entities.User>();
    }
}