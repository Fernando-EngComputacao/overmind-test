using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Teste.Services.Interfaces;
using System.Text.Json;
using Teste.Models.Device;
using Teste.Models;
using Teste.Config.Interface;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Teste.Services
{
    public class StoreService : IStoreService
    {
        public string Diretorio { get; set; }

        public StoreService(IConfigVariable config)
        {
            Diretorio = config.LocalArmazenamento;
        }

        public async Task<List<Device>> ObterProdutos()
        {
            var listaDevices = new List<Device>();
            var _url = "https://api.restful-api.dev/objects";
            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync(_url);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (responseContent.StartsWith("{") || responseContent.StartsWith("["))
                    {
                        listaDevices = JsonSerializer.Deserialize<List<Device>>(responseContent);

                        var applePrices = listaDevices
                            .Where(x => x.name.ToUpper().Contains("APPLE") &&
                                        x.data != null && x.data.price != null)
                            .Select(x => new Apple
                            {
                                Nome = x.name,
                                Preco = x.data.price
                            })
                            .ToList();

                        GerarCSV(applePrices);
                    }
                    else
                    {
                        Console.WriteLine("A resposta não está no formato JSON esperado.");
                    }
                }
                else
                {
                    Console.WriteLine($"Erro na resposta da API: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
            }

            return listaDevices;
        }

        protected void GerarCSV(List<Apple> appleList)
        {
            if (appleList == null || appleList.Count == 0) return;

            var diretorio = GetDiretorio("apple_list.csv");
            var linhas = new List<string>();
            linhas.Add("Nome;Preco");

            foreach (var apple in appleList)
            {
                var line = $"{apple.Nome};{apple.Preco}";
                linhas.Add(line);
                
            }
            if (!File.Exists(diretorio))

                File.WriteAllLines(diretorio, linhas);
            else
                File.AppendAllLines(diretorio, linhas.Skip(1));

            Console.WriteLine($"Arquivo gerado em: {diretorio}");
        }

        protected string GetDiretorio(string fileName)
        {
            return Diretorio + $"{fileName}";
        }
    }
}
