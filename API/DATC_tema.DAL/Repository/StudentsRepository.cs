using DATC_tema.DAL.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DATC_tema.DAL.Repository;

public class StudentsRepository : IStudentsRepository
{
    private CloudTableClient? _tableClient;

    private CloudTable? _studentsTable;

    private string _connectionString = "";

    public StudentsRepository(IConfiguration configuration)
    {
        _connectionString = configuration["StorageConnectionString"];
        Task.Run(async () => { await InitializeTable(); })
            .GetAwaiter()
            .GetResult();
    }

    public async Task CreateStudent(Student student)
    {
        var insertOperation = TableOperation.Insert(student);

        if (_studentsTable != null)
        {
            await _studentsTable.ExecuteAsync(insertOperation);
        }
    }

    public async Task<IEnumerable<Student>> GetStudentsByFacultyAsync(string faculty)
    {
        var students = new List<Student>();

        TableQuery<Student> query = new TableQuery<Student>().Where(TableQuery.GenerateFilterCondition("Faculty", QueryComparisons.Equal, faculty));

        TableContinuationToken token = null;
        do
        {
            TableQuerySegment<Student> resultSegment = await _studentsTable.ExecuteQuerySegmentedAsync(query, token);
            token = resultSegment.ContinuationToken;

            students.AddRange(resultSegment.Results);

        } while (token != null);

        return students;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        var students = new List<Student>();

        TableQuery<Student> query = new TableQuery<Student>(); //.Where(TableQuery.GenerateFilterCondition("FirstName", QueryComparisons.Equal, "Istvan"));

        TableContinuationToken token = null;
        do
        {
            TableQuerySegment<Student> resultSegment = await _studentsTable.ExecuteQuerySegmentedAsync(query, token);
            token = resultSegment.ContinuationToken;

            students.AddRange(resultSegment.Results);

        } while (token != null);

        return students;
    }

    private async Task InitializeTable()
    {
        var account = CloudStorageAccount.Parse(_connectionString);
        _tableClient = account.CreateCloudTableClient();

        _studentsTable = _tableClient.GetTableReference("students");

        await _studentsTable.CreateIfNotExistsAsync();
    }
}
