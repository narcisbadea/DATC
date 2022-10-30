using DATC_tema.DAL.Entity;

namespace DATC_tema.DAL.Repository;

public interface IStudentsRepository
{
    Task CreateStudent(Student student);
    Task<List<Student>> GetAllStudents();
    Task<IEnumerable<Student>> GetStudentsByFacultyAsync(string faculty);
}