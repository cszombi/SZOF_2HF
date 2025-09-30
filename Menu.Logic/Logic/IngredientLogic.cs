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
    public class IngredientLogic
    {
        public Repository<Ingredient> repo;
        public Mapper mapper;

        public IngredientLogic(Repository<Ingredient> repo, DtoProvider provider)
        {
            this.repo = repo;
            this.mapper = provider.mapper;
        }


        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return repo.GetAll().Select(t => mapper.Map<Ingredient>(t));
        }


        public async Task Create(IngredientCreateUpdeteDto dto)
        {
            var ingredient = mapper.Map<Ingredient>(dto);
            if (repo.GetAll().FirstOrDefault(x => x.Name == ingredient.Name) == null)
            {
                repo.Create(ingredient);
            }
            else
            {
                throw new ArgumentException("Ilyen étel már létezik!");
            }

        }


        public void Delete(string id)
        {
            repo.DeleteById(id);

        }

        public void UpdateIngredient(string id, IngredientCreateUpdeteDto dto)
        {
            var old = repo.FindById(id);
            mapper.Map(dto, old);
            repo.Update(old);
        }

    }
}
