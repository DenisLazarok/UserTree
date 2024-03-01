using AutoMapper;

namespace UserTree.Application.Extensions;

public interface IMapFrom<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}
