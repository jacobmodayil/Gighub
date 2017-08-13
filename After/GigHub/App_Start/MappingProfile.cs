using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Core.Dtos;
using GigHub.Core.Models;

namespace GigHub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<ApplicationUser, UserDto>();
                x.CreateMap<Genre, GenreDto>();
                x.CreateMap<Notification, NotificationDto>();
            });

            config.CreateMapper();
        }
    }
}