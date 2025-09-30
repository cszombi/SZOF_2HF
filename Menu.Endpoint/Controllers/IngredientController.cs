using Menu.Entities.Dto;
using Menu.Entities.Entity;
using Menu.Logic.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Endpoint.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IngredientController
    {
        IngredientLogic logic;
        public IngredientController(IngredientLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<IngredientShortViewDto> Get()
        {
            return logic.GetAllIngredients();
        }

        [HttpPost]
        public void Post(IngredientCreateUpdeteDto dto)
        {
            logic.Create(dto);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] IngredientCreateUpdeteDto dto)
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
