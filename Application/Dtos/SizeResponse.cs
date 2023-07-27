using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos;

public class SizeResponse : IMapWith<Size>
{
    public int Id { get; set; }
    public double Value { get; set; }
    public string UnitName { get; set; } = null!;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Size, SizeResponse>();
    }
}
