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
    public class MealLogic
    {
        public Repository<Meal> repo;
        public Mapper mapper;

        public MealLogic(Repository<Meal> repo, DtoProvider provider)
        {
            this.repo = repo;
            this.mapper = provider.mapper;
        }


        public IEnumerable<MealShortViewDto> GetAllMeals()
        {
            return repo.GetAll().Select(t => mapper.Map<MealShortViewDto>(t));
        }

        public async Task Create(MealCreateUpdateDto dto)
        {
            var meal = mapper.Map<Meal>(dto);
            if (repo.GetAll().FirstOrDefault(x => x.Name == meal.Name) == null)
            {
                repo.Create(meal);
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

        public void UpdateMovie(string id, MealCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            mapper.Map(dto, old);
            repo.Update(old);
        }

        
    }
}
