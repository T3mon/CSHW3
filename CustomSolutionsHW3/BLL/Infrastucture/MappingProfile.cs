using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastucture
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<HiringHistorie, HiringHistorieDto>();
            CreateMap<HiringHistorieDto, HiringHistorie>();

            CreateMap<HiringHistorie, HiringHistorieDto>();
            CreateMap<HiringHistorieDto, HiringHistorie>();


        }

    }
}
