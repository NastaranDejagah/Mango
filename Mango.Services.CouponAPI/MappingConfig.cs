﻿using AutoMapper;
using Mango.Services.CouponAPI.Model;
using Mango.Services.CouponAPI.Model.Dto;

namespace Mango.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
                {
                    config.CreateMap<Coupon, CouponDto>();
                    config.CreateMap<CouponDto, Coupon>();
                });

            return mappingConfig;
        }
    }
}