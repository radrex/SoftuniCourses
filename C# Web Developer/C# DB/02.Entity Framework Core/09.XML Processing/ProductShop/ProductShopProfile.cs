using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //--------- TASK 01 ---- IMPORT USERS --------------------
            this.CreateMap<ImportUserDto, User>();

            //--------- TASK 02 ---- IMPORT PRODUCTS -----------------
            this.CreateMap<ImportProductDto, Product>();

            //--------- TASK 03 ---- IMPORT CATEGORIES ---------------
            this.CreateMap<ImportCategoryDto, Category>();

            //--------- TASK 04 ---- IMPORT CATEGORIES AND PRODUCTS ---------------
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
