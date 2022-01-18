using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApisCallingApis.Dto;
using ApisCallingApis.Models;

namespace ApisCallingApis.Profiles
{
    public class ComandosProfile : Profile
    {
        public ComandosProfile()
        {
            // Source -> target
            CreateMap<ComandoUpdateDto, Comando>();
        }
    }
}
