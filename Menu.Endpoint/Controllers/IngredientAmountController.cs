using Menu.Entities.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Endpoint.Controllers
{
    public class IngredientAmountController
    {
        [ApiController]
        [Route("[controller]")]
        public class IngredientQuantityController : ControllerBase
        {
            IngredientsAmount logic;
            public IngredientQuantityController(IngredientQuantityLogic logic)
            {
                this.logic = logic;
            }

            [HttpGet]
            public IEnumerable<IngredientQuantityGetDto> Get()
            {
                return logic.Read();
            }

            [HttpPost]
            public async Task Post(IngredientQuantityPostPutDto dto)
            {
                await logic.Create(dto);
            }

            [HttpDelete("{id}")]
            public async Task Delete(string id)
            {
                await logic.Delete(id);
            }

            [HttpPut("{id}")]
            public async Task Update(string id, [FromBody] IngredientQuantityPostPutDto dto)
            {
                await logic.Update(id, dto);
            }
        }
}
