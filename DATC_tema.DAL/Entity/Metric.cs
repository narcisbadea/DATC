using Microsoft.WindowsAzure.Storage.Table;

namespace DATC_tema.DAL.Entity;

public class Metric : TableEntity
{
    public int CountStudents { get; set; }

    public Metric()
    {
        this.PartitionKey = "Count";
        this.RowKey = Guid.NewGuid().ToString();
    }

}
