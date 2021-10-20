using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;
using Pizzaria.Services;

namespace Pizzaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if(pizza == null)
                return NotFound();

            return pizza;
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {            
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest(); // Erro: a pizza não bate com o ID entregue

            var existingPizza = PizzaService.Get(id);
            if(existingPizza is null)
                return NotFound(); // Erro: não encontrou a pizza dada pelo ID

            PizzaService.Update(pizza);           

            return NoContent(); // Sem conteúdo de retorno 204: deu certo mas não há o que fazer
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}