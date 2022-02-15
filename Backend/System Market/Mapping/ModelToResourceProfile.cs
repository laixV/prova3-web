using Super_Market.Domain.Models;
using Super_Market.Resources;
using AutoMapper;

namespace Super_Market.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<User, AuthUserResource>();
        }
    }
}