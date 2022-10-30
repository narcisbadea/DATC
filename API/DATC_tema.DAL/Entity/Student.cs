using Microsoft.WindowsAzure.Storage.Table;

namespace DATC_tema.DAL.Entity;

public class Student : TableEntity
{
    public string university { get; set; }
    public string cnp { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string Faculty { get; set; }
}
