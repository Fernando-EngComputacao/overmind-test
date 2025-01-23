using System.Text.Json;
using Teste.Client.Interfaces;
using Teste.Core.Config.Interface;
using Teste.Models.Apple;
using Teste.Models.Device;

namespace Teste.Client;

public class ClientDevice : IClientDevices
{
    private string PathWay { get; set; }
    private string FileName { get; set; }

    public ClientDevice(IConfigVariable config)
    {
        PathWay = config.LocalArmazenamento;
        FileName = config.NomeArquivo;
    }

    public async Task<List<Apple>> GetAppleList()
    {
        var devicesList = await GetDeviceList();

        var applePrices = devicesList
            .Where(x => x.name.ToUpper().Contains("APPLE") &&
                        x.data != null && x.data.price != null)
            .Select(x => new Apple
            {
                Nome = x.name,
                Preco = x.data.price
            })
            .ToList();

        //Gera Lista CSV
        GenerateCSV(applePrices);

        return applePrices;
    }

    public async Task<List<Device>> GetDeviceList()
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
                    return listaDevices;

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

        return null;
    }

    protected void GenerateCSV(List<Apple> appleList)
    {
        if (appleList == null || appleList.Count == 0) return;

        var diretorio = GetDiretorio();
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

    protected string GetDiretorio()
    {
        return Path.Combine(PathWay + $"{FileName}");
    }

}