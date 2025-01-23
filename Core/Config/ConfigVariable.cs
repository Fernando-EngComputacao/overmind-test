using Teste.Core.Config.Interface;

namespace Teste.Core.Config;

public class ConfigVariable : IConfigVariable
{
    public const string CONFIG_NAME = "SalveCSV";
    public string LocalArmazenamento { get; set; }
    public string NomeArquivo { get; set; }
}
