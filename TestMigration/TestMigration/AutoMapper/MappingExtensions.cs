using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TestMigration.Models;
using TestMigration.Domain.core;


namespace TestMigration.AutoMapper
{   
    public static class MappingExtensions
    {    

        

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public static ModuleViewModel ToModel(this Module entity)
        {
            return entity.MapTo<Module, ModuleViewModel>();
        }
    }
}