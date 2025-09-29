using Menu.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Menu.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealController
    {
        public MealController()
        {
                
        }

        [HttpGet]
        public IEnumerable<Meal> Get()
        {
            
        }

        [HttpPost]
        public void Post()
        {

        }

        [HttpPut]
        public void Update([FromBody] Meal value)
        {
            
        }

        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
