using DATC_tema.DAL.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DATC_tema.DAL.Repository;

public class MetricsRepository : IMetricsRepository
{
    private CloudTableClient? _tableClient;

    private CloudTable? _studentsTable;

    private string _connectionString = "";

    public MetricsRepository(IConfiguration configuration)
    {
        _connectionString = configuration["StorageConnectionString"];
        Task.Run(async () => { await InitializeTable(); })
            .GetAwaiter()
            .GetResult();
    }

    public async Task CreateMetric(Metric metric)
    {
        var insertOperation = TableOperation.Insert(metric);

        if (_studentsTable != null)
        {
            await _studentsTable.ExecuteAsync(insertOperation);
        }
    }



    private async Task InitializeTable()
    {
        var account = CloudStorageAccount.Parse(_connectionString);
        _tableClient = account.CreateCloudTableClient();

        _studentsTable = _tableClient.GetTableReference("metrics");

        await _studentsTable.CreateIfNotExistsAsync();
    }
}
