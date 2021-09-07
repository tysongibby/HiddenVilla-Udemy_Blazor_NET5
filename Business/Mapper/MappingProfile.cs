using AutoMapper;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelRoomDto, HotelRoom>();
            CreateMap<HotelRoom, HotelRoomDto>();

            // does .ReverseMap adds the map, too, so the map and the reverse map can be written in one line
            CreateMap<HotelRoomImage, HotelRoomImageDto>().ReverseMap();
        }
    }
}
