using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WebApiTeste.Models;

namespace ConsumidorDeServicos
{
    class Program
    {
        static void Main(string[] args)
        {
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
            client.ExecuteAsync<Restaurante>(request2, response => {
                                Console.WriteLine();
                                Console.WriteLine("Serviço BuscarRestaurantePorId()");
                                Console.WriteLine(response.Data.Id);
                                Console.WriteLine(response.Data.Nome);
                                Console.WriteLine(response.Data.Endereco);
                            });

            //Síncrono
            //IRestResponse<Restaurante> response2 = client.Execute<Restaurante>(request2);
            //var teste = response2.Data.Nome;

                                                
            Restaurante rest = new Restaurante();
            rest.Id = 1;
            rest.Nome = "Restaurante Ziquinha";
            rest.Endereco = "Avenida Rio Branco";                       

            var request3 = new RestRequest("Restaurante/AdicionarRestaurante", Method.POST);

            var json = request3.JsonSerializer.Serialize(rest);                        
            request.RequestFormat = DataFormat.Json;
            request3.AddParameter("restaurante", json);            
            
            client.ExecuteAsync<Restaurante>(request3, response =>
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Serviço AdicionarRestaurante()");
                                                Console.WriteLine(response.StatusDescription);
                                            });


            Console.ReadLine();
        }
    }
}
