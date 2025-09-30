using Menu.Entities.Dto;
using Menu.Entities.Entity;
using Menu.Logic.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientAmountController
    {
        IngredientsAmountLogic logic;
        public IngredientAmountController(IngredientsAmountLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<IngredientsAmountShortViewDto> Get()
        {
            return logic.GetAllIngredientAmounts();
        }

        [HttpPost]
        public void Post(IngredientsAmountCreateUpdateDto dto)
        {
            logic.Create(dto);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] IngredientsAmountCreateUpdateDto dto)
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
