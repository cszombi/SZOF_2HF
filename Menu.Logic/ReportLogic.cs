using AutoMapper;
using ReportApp.Entities.Dto.Report;
using ReportApp.Entities.Entity;
using ReportApp.Logic.Dto;
using ReportApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.Logic
{
    public class ReportLogic
    {
        public Repository<Report> repository;
        public Mapper mapper;

        public ReportLogic(Repository<Report> repository, DtoProvider provider)
        {
            this.repository = repository;
            this.mapper = provider.mapper;
        }

        public IEnumerable<ReportViewDto> Read()
        {

            return repository.GetAll().Select(t => mapper.Map<ReportViewDto>(t));
        }

        public async Task Create(ReportCreateDto dto, string id)
        {
            var report = mapper.Map<Report>(dto);
            report.CreatedAt = DateTime.UtcNow;
            report.Title = id;
            await repository.CreateAsync(report);
        }

    }
}
