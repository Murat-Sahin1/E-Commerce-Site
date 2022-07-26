using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    //Mapping helper for reducing the workload of controllers
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                    //ForMember -> First parameter is the destination, to be set to something.
                    //Second parameter is for the expression for options
                    .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                    .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name));
                                                        //MapFrom is where do we want to get the property from that we want to insert into our product brand field                                  
        }
    }
}