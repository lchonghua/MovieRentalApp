using AutoMapper;
using MovieRentalApp.Dtos;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //automapper is a convention based mapping tool: the mapping is based on the property names in the two objects
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}