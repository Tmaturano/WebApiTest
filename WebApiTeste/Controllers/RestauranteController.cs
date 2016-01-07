using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTeste.Models;

namespace WebApiTeste.Controllers
{
    public class RestauranteController : ApiController
    {
        private List<Restaurante> _restaurantes = null;

        public RestauranteController()
        {
            if (_restaurantes == null)
            {
                _restaurantes = new List<Restaurante>();
                _restaurantes.Add(new Restaurante() { Id = 1, Nome = "Restaurante Linx Joinville", Endereco = "Rua Tenente Antônio João" });
                _restaurantes.Add(new Restaurante() { Id = 2, Nome = "Restaurante Linx São Paulo", Endereco = "Rua Morumbi" });
                _restaurantes.Add(new Restaurante() { Id = 3, Nome = "Restaurante Linx Rio de Janeiro", Endereco = "Rua Copacabana"});
            }
        }

        [HttpGet]
        [ActionName("FindAll")]        
        public IEnumerable<Restaurante> BuscarTodosRestaurantes()
        {
            return _restaurantes;
        }

                        
        [AcceptVerbs("GET")]
        public IHttpActionResult BuscarRestaurantePorId(int id)
        {
            var restaurante = _restaurantes.FirstOrDefault(p => p.Id.Equals(id));
            
            if (restaurante == null)
                return NotFound();

            return Ok(restaurante);
        }

        [HttpPost]
        public HttpResponseMessage AdicionarRestaurante(Restaurante restaurante)
        {
            if (!CheckIfRestaurantExists(restaurante.Id))
            {
                _restaurantes.Add(restaurante);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        private bool CheckIfRestaurantExists(int id)
        {
            return( _restaurantes.Where(p => p.Id.Equals(id)).Any());            
        }

    }
}
