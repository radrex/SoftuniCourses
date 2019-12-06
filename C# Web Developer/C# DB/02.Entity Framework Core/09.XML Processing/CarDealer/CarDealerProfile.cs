using AutoMapper;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //--------- TASK 09 ---- IMPORT SUPPLIERS ---------------
            this.CreateMap<ImportSupplierDto, Supplier>();

            //--------  TASK 10 ---- IMPORT PARTS -------------------
            this.CreateMap<ImportPartDto, Part>();

            //--------- TASK 12 ---- IMPORT CUSTOMERS ---------------
            this.CreateMap<ImportCustomerDto, Customer>();

            //--------- TASK 13 ---- IMPORT SALES -------------------
            this.CreateMap<ImportSaleDto, Sale>();

        }
    }
}
