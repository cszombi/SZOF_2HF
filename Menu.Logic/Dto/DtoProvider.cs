using AutoMapper;
using Menu.Entities.Dto;
using Menu.Entities.Entity;
using Microsoft.CodeAnalysis;
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MealCreateUpdateDto, Report>();
                cfg.CreateMap<Report, MealShortViewDto>()
                    .ForMember(dest => dest.IngredientQuantities, opt => opt.MapFrom(src => src.IngredientsAmounts))
                    .AfterMap((src, dest) =>
                        dest.Calorie = src.IngredientsAmounts?.Sum(x => x.ingredient.Calorie * x.Amount / 100) ?? 0
                    );
                cfg.CreateMap<IngredientCreateUpdeteDto, User>();
                cfg.CreateMap<User, IngredientShortViewDto>();
                cfg.CreateMap<IngredientsAmountCreateUpdateDto, IngredientsAmount>();
                cfg.CreateMap<IngredientsAmount,IngredientsAmountShortViewDto>();
            });
            mapper = new Mapper(config);
        }
    }
}
