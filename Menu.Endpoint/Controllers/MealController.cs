using Menu.Entities.Dto;
using Menu.Entities.Entity;
using Menu.Logic.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Menu.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealController
    {
        MealLogic logic;
        public MealController(MealLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<MealShortViewDto> Get()
        {
            return logic.GetAllMeals();
        }

        [HttpPost]
        public void Post(MealCreateUpdateDto dto)
        {
            logic.Create(dto);
        }

        [HttpPut("{id}")]
        public void Update(string id,[FromBody] MealCreateUpdateDto dto)
        {
            logic.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            logic.Delete(id);
        }
    }
}
