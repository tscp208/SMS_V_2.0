using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SMS_Entities;
using SMS.Models;

namespace SMS.CustomMapper
{
    public static class CustomMapper
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<UserTypeEntity, SMS.Models.UserType.UserTypeViewModel>()
                //    .ForMember(usertype => usertype.UserTypeID, map => map.MapFrom(p => p.UserTypeID))
                //    .ForMember(usertype => usertype.UserTypeName, map => map.MapFrom(p => p.UserTypeName))
                //    .ForMember(usertype => usertype.UserTypeDesc, map => map.MapFrom(p => p.UserTypeDesc));

                cfg.CreateMap<UserTypeEntity, SMS.Models.UserType.UserTypeModel>()
                    .ForMember(usertype => usertype.UserTypeID, map => map.MapFrom(p => p.UserTypeID))
                    .ForMember(usertype => usertype.UserTypeName, map => map.MapFrom(p => p.UserTypeName))
                    .ForMember(usertype => usertype.UserTypeDesc, map => map.MapFrom(p => p.UserTypeDesc));

                cfg.CreateMap<SMS.Models.UserType.UserTypeModel, UserTypeEntity>()
                    .ForMember(usertype => usertype.UserTypeID, map => map.MapFrom(p => p.UserTypeID))
                    .ForMember(usertype => usertype.UserTypeName, map => map.MapFrom(p => p.UserTypeName))
                    .ForMember(usertype => usertype.UserTypeDesc, map => map.MapFrom(p => p.UserTypeDesc))
                    .ForMember(usertype => usertype.CreatedBy, map => map.MapFrom(p => p.CreatedBy))
                    .ForMember(usertype => usertype.CreatedOn, map => map.MapFrom(p => p.CreatedOn))
                    .ForMember(usertype => usertype.ModifiedBy, map => map.MapFrom(p => p.ModifiedBy))
                    .ForMember(usertype => usertype.ModifiedOn, map => map.MapFrom(p => p.ModifiedOn))
                    .ForMember(usertype => usertype.IsDeleted, map => map.MapFrom(p => p.IsDeleted));
            });
        }
    }
}