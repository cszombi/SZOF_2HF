using AutoMapper;
using Menu.Entities.Dto;
using Menu.Entities.Entity;
using Menu.Logic.Dto;
using Menu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Logic.Logic
{
    public class IngredientsAmountLogic
    {
        public Repository<IngredientsAmount> repo;
        public Mapper mapper;

        public IngredientsAmountLogic(Repository<IngredientsAmount> repo, DtoProvider provider)
        {
            this.repo = repo;
            this.mapper = provider.mapper;
        }


        public IEnumerable<IngredientsAmountShortViewDto> GetAllIngredientAmounts()
        {
            return repo.GetAll().Select(t => mapper.Map<IngredientsAmountShortViewDto>(t));
        }


        public async Task Create(IngredientsAmountCreateUpdateDto dto)
        {
            var ingredientAmount = mapper.Map<IngredientsAmount>(dto);
            repo.Create(ingredientAmount);

        }


        public void Delete(string id)
        {
            repo.DeleteById(id);

        }

        public void Update(string id, IngredientsAmountCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            if (old != null)
            {
                mapper.Map(dto, old);
                repo.Update(old);
            }
        }

    }
}
