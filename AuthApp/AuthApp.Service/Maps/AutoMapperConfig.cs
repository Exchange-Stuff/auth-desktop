﻿using AutoMapper;

namespace AuthApp.Service.Maps
{
    public class AutoMapperConfig
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            var config = new MapperConfiguration(x =>
            {
                x.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod!.IsAssembly;
                x.AddProfile<MapperHandler>();
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class MapperHandler : Profile
    {
        public MapperHandler()
        {
            
        }
    }
}
