using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TestMigration.Domain.core;
using TestMigration.Models;

namespace TestMigration.AutoMapper
{
    public class AutoMapperStartupTask
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Module, ModuleViewModel>());
        }
    }
}