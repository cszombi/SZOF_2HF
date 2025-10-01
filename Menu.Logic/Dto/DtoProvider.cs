using AutoMapper;
using Menu.Entities.Dto;
using Menu.Entities.Entity;
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
                cfg.CreateMap<MealCreateUpdateDto, Meal>();
                cfg.CreateMap<Meal, MealShortViewDto>()
                 .ForMember(dest => dest.Ingre, opt => opt.MapFrom(src => src.IngredientsAmounts.Select(ia => ia.Ingredient))
                 .AfterMap((src, dest) => dest.Ingredients = dest.Ingredients.DistinctBy(i => i.Id).ToList()));
                cfg.CreateMap<IngredientCreateUpdeteDto, Ingredient>();
                cfg.CreateMap<Ingredient, IngredientShortViewDto>();
                cfg.CreateMap<IngredientsAmountCreateUpdateDto, IngredientsAmount>();
                cfg.CreateMap<IngredientsAmount,IngredientsAmountShortViewDto>();
            });
            mapper = new Mapper(config);
        }
    }
}
