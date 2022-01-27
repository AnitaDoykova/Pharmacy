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
            CreateMap<Client, ClientResponse>();
            CreateMap<ClientRequests, Client>();
            CreateMap<ClientUpdateRequests, Client>().ReverseMap();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeRequests, Employee>();
            CreateMap<EmployeeUpdateRequests, Employee>().ReverseMap();
            CreateMap<Products, ProductsResponse>();
            CreateMap<ProductsRequests, Products>();
            CreateMap<ProductsUpdateRequests, Products>().ReverseMap();
            CreateMap<Shift, ShiftResponse>();
            CreateMap<ShiftRequests, Shift>();
            CreateMap<ShiftUpdateRequests, Shift>().ReverseMap();

            
        }
    }
}
