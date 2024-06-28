using AutoMapper;
using BackendTest.API.Domain.Entities;
using BackendTest.API.Models;

namespace BackendTest.API.Domain.Profiles
{
    public class BackendTesteProfiles : Profile
    {
        public BackendTesteProfiles()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<Billing, BillingModel>();
            CreateMap<BillingModel, Billing>();

            CreateMap<BillingLines, BillingLinesModel>();
            CreateMap<BillingLinesModel, BillingLines>();
        }
    }
}
