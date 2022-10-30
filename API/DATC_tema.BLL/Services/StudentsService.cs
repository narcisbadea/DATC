using AutoMapper;
using DATC_tema.BLL.DTOs;
using DATC_tema.DAL.Entity;
using DATC_tema.DAL.Repository;

namespace DATC_tema.BLL.Services;

public class StudentsService : IStudentsService
{
    private readonly IStudentsRepository _studentsRepository;
    private readonly IMapper _mapper;

    public StudentsService(IStudentsRepository studentsRepository, IMapper mapper)
    {
        _studentsRepository = studentsRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<StudentResponseDTO>?> GetAllStudents()
    {
        var result = await _studentsRepository.GetAllStudents();
        return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResponseDTO>>(result);
    }

    public async Task<StudentResponseDTO> PostStudent(StudentRequestDTO student)
    {
        var studentToAdd = _mapper.Map<Student>(student);
        await _studentsRepository.CreateStudent(studentToAdd);
        return _mapper.Map<Student, StudentResponseDTO>(studentToAdd);
    }

    public async Task<IEnumerable<StudentResponseDTO>> GetStudentcsByFacultyAsync(string faculty)
    {
        var students = await _studentsRepository.GetStudentsByFacultyAsync(faculty);
        return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResponseDTO>>(students);
    }

    public async Task<int> CountStudents()
    {
        var countStudents = (await _studentsRepository.GetAllStudents()).Count();
        return countStudents;
    }

}
