using AutoMapper;


namespace CqrsSampleFirst.Application.Common
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }
    }
}
