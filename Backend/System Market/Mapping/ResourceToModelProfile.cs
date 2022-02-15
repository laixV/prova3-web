using Super_Market.Domain.Models;
using Super_Market.Resources;
using AutoMapper;

namespace Super_Market.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveUserResource, User>();
        }
    }
}