using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PuppyApp.DTOS;
using PuppyApp.Models;

namespace PuppyApp {
    public static class AutoMapperConfig {

        public static IMapper AppMapper { get; private set; }

        public static void RegisterMappings() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserProfile, UserProfileDTO>()
                .ForMember(dest => dest.AddressLatitude, opts => opts.MapFrom(src => src.Leaves.Latitude))
                .ForMember(dest => dest.AddressLongitude, opts => opts.MapFrom(src => src.Leaves.Longitude));

                cfg.CreateMap<HistoryPoint, HistoryGeoJsonDTO>()
                .ForMember(d => d.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(d => d.Latitude, opts => opts.MapFrom(src => src.Location.Latitude))
                .ForMember(d => d.Longitude, opts => opts.MapFrom(src => src.Location.Longitude));
            });

            //config.cre
            AppMapper = config.CreateMapper();
            
        }
    }
}