using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Utils;

namespace Application.Dtos;

public class PagedListResponse<T> : IMapWith<PagedList<T>>
{
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<T> Items { get; set; } = null!;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(PagedList<>), typeof(PagedListResponse<>))
            .ForMember("Items", options => options.MapFrom(x => x));
    }
}