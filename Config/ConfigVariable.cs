using Teste.Config.Interface;

namespace Teste.Config;

public class ConfigVariable : IConfigVariable
{
    public const string CONFIG_NAME = "SalveCSV";
    public string LocalArmazenamento { get; set; }
}
