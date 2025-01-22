using System.Text.Json.Serialization;

namespace Teste.Models.Device;

public class Dados
{
    public string color { get; set; }
    public string capacity { get; set; }
    public decimal price { get; set; }
    public string generation { get; set; }
    public int? year { get; set; }
    public string cPUModel { get; set; }
    public string hardDiskSize { get; set; }
    public string strapColour { get; set; }
    public string caseSize { get; set; }
    public string description { get; set; }
    public string screenSize { get; set; }
}
