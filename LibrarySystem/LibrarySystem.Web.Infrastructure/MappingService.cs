using AutoMapper;

using AutoMapper;

using LibrarySystem.Web.Infrastucture.Contracts;

namespace LibrarySystem.Web.Infrastucture
{
    public class MappingService : IMappingService
    {
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}