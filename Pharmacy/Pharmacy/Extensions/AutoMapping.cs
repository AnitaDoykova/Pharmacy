using AutoMapper;
using Pharmacy.Models.DTO;
using Pharmacy.Models.Requests;
using Pharmacy.Models.Responses;

namespace Pharmacy.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Client, ClientResponse>().ReverseMap();
            CreateMap<ClientRequests, Client>().ReverseMap();
            CreateMap<ClientUpdateRequests, Client>().ReverseMap();
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<EmployeeRequests, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateRequests, Employee>().ReverseMap();
            CreateMap<Products, ProductsResponse>().ReverseMap();
            CreateMap<ProductsRequests, Products>().ReverseMap();
            CreateMap<ProductsUpdateRequests, Products>().ReverseMap();
            CreateMap<Shift, ShiftResponse>().ReverseMap();
            CreateMap<ShiftRequests, Shift>().ReverseMap();
            CreateMap<ShiftUpdateRequests, Shift>().ReverseMap();

            
        }
    }
}
