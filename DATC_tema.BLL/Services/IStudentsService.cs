using DATC_tema.BLL.DTOs;

namespace DATC_tema.BLL.Services
{
    public interface IStudentsService
    {
        Task<int> CountStudents();
        Task<IEnumerable<StudentResponseDTO>?> GetAllStudents();
        Task<IEnumerable<StudentResponseDTO>> GetStudentcsByFacultyAsync(string faculty);
        Task<StudentResponseDTO> PostStudent(StudentRequestDTO student);
    }
}