using Menu.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Endpoint.Controllers
{
    [ApiController]
    public class IngredientController
    {
        public IngredientController()
        {
                
        }

        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {

        }

        [HttpPost]
        public void Post()
        {

        }

        [HttpPut]
        public void Update([FromBody] Ingredient value)
        {

        }

        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
