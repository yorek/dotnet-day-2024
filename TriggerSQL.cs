using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotNetDevDay;

public class SampleTable {
    public int Id { get; set; }
    public string? SomeValue { get; set; }
    public string? SomeOtherValue { get; set; }
}

public class TriggerSQL(ILoggerFactory loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<TriggerSQL>();

    [Function("TriggerSQL")]
    public void Run(
        [SqlTrigger("[dbo].[SampleTable]", "AZURE_SQL_CONNECTION_STRING")]
        IReadOnlyList<SqlChange<SampleTable>> changes)
    {
        if (changes.Count > 0)
        {
            foreach (var change in changes)
            {
                _logger.LogInformation(JsonSerializer.Serialize(new {
                    change.Operation,
                    change.Item
                }));
            }
        }
    }
}
