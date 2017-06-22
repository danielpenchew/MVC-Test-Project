using AutoMapper;

namespace LibrarySystem.Web.Infrastucture.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
