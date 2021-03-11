using AutoMapper;
using Billing.API.Models;
using Billing.API.Models.Dtos;

namespace Billing.API.Profiles
{
    /// <summary>
    /// Class for Automapper Mappings
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<InvoiceCreateDto, Invoice>();
            //CreateMap<Invoice, InvoiceListItem>()
            //    .ForMember(s => s.CustomerName, x => x.MapFrom(src => src.Customer.LastName + ", " + src.Customer.FirstName));
        }
    }
}
