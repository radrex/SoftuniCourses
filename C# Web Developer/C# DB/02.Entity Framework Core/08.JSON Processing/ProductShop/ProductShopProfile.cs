using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ProductDetailsDto>();

            this.CreateMap<User, SoldProductsDto>()
                .ForMember(x => x.Count, y => y.MapFrom(x => x.ProductsSold.Where(ps => ps.Buyer != null).Count()))
                .ForMember(x => x.Products, y => y.MapFrom(x => x.ProductsSold.Where(ps => ps.Buyer != null)));


            this.CreateMap<User, UserDetailsDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(x => x));

        }
    }
}
