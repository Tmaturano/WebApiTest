using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WebApiTeste.Models;
using ConsumidorDeServicos.RestauranteService;

namespace ConsumidorDeServicos
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Web Api

            Console.WriteLine("Consuming the api service...");
            Console.WriteLine();

            var client = new RestClient("http://localhost:57142/api/");

            var request = new RestRequest("Restaurante/FindAll", Method.GET);
            request.RequestFormat = DataFormat.Json;
            
            //Assíncrono
            client.ExecuteAsync(request, response => {
                                    Console.WriteLine("Serviço BuscarTodosRestaurantes()");
                                    Console.WriteLine(response.Content); 
                                });

            //Síncrono
            //IRestResponse responseSincrono = client.Execute(request);
           
            var request2 = new RestRequest("Restaurante/BuscarRestaurantePorId", Method.GET);
            request2.AddParameter("id", 1);
            request2.RequestFormat = DataFormat.Json;

            //Assíncrono
            client.ExecuteAsync<WebApiTeste.Models.Restaurante>(request2, response => {
                                Console.WriteLine();
                                Console.WriteLine("Serviço BuscarRestaurantePorId()");
                                Console.WriteLine(response.Data.Id);
                                Console.WriteLine(response.Data.Nome);
                                Console.WriteLine(response.Data.Endereco);
                            });

            //Síncrono
            //IRestResponse<Restaurante> response2 = client.Execute<Restaurante>(request2);
            //var teste = response2.Data.Nome;
                        
            WebApiTeste.Models.Restaurante restApi = new WebApiTeste.Models.Restaurante();
            restApi.Id = 1;
            restApi.Nome = "Restaurante Ziquinha";
            restApi.Endereco = "Avenida Rio Branco";                       

            var request3 = new RestRequest("Restaurante/AdicionarRestaurante", Method.POST);

            var json = request3.JsonSerializer.Serialize(restApi);                        
            request.RequestFormat = DataFormat.Json;
            request3.AddParameter("restaurante", json);            
            
            client.ExecuteAsync<WebApiTeste.Models.Restaurante>(request3, response =>
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Serviço AdicionarRestaurante()");
                                                Console.WriteLine(response.StatusDescription);
                                            });
            
            Console.ReadLine();
            #endregion

            #region WCF

            Console.WriteLine("==============================");
            Console.WriteLine("Consuming the wcf service");
            Console.WriteLine();
                        
            RestauranteServiceClient restauranteService = new RestauranteServiceClient();

            Console.WriteLine("Searching for all restaurants...");
            IEnumerable<ConsumidorDeServicos.RestauranteService.Restaurante> restaurantes = restauranteService.BuscarTodosRestaurantes();

            foreach (var item in restaurantes)
            {
                Console.WriteLine("Restaurant:");
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Nome);
                Console.WriteLine(item.Endereco);
                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine("Finding a restaurant by it's id...");
            ConsumidorDeServicos.RestauranteService.Restaurante restaurante = restauranteService.BuscarRestaurantePorId(1);
            Console.WriteLine("Restaurant:");
            Console.WriteLine(restaurante.Id);
            Console.WriteLine(restaurante.Nome);
            Console.WriteLine(restaurante.Endereco);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Adding a new restaurant in the list...");
            ConsumidorDeServicos.RestauranteService.Restaurante restWcf = new ConsumidorDeServicos.RestauranteService.Restaurante();
            restWcf.Id = 5;
            restWcf.Nome = "Restaurante Ziquinha";
            restWcf.Endereco = "Avenida Rio Branco";

            Console.WriteLine(restauranteService.AdicionarRestaurante(restWcf) ? "Created" : "Restaurant alread exists");
            
            #endregion

            Console.ReadKey();
        }
    }
}
