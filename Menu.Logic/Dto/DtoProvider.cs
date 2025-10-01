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
                cfg.CreateMap<MealCreateUpdateDto, Meal>();
                cfg.CreateMap<Meal, MealShortViewDto>()
                    .AfterMap((src, dest) => dest.Calorie = src.Ingredients?.Count > 0 ? (src.Ingredients.Sum(r => r.Calorie * (r.IngredientsAmounts.Select(x => x.Amount)).Single() / 100)) : 0);
                cfg.CreateMap<IngredientCreateUpdeteDto, Ingredient>();
                cfg.CreateMap<Ingredient, IngredientShortViewDto>();
                cfg.CreateMap<IngredientsAmountCreateUpdateDto, IngredientsAmount>();
                cfg.CreateMap<IngredientsAmount,IngredientsAmountShortViewDto>();
            });
            mapper = new Mapper(config);
        }
    }
}
