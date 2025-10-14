using AutoMapper;
using Menu.Entities.Entity;
using Microsoft.CodeAnalysis;
using ReportApp.Entities.Dto.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Logic.Dto
{
    public class DtoProvider
    {
        public Mapper mapper { get; }

        public DtoProvider()
        {
            
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportCreateDto, Report>();
                cfg.CreateMap<Report, ReportViewDto>()
                    .AfterMap((src, dest) => dest.Title = src.Title);
            }));
        }
    }
}
