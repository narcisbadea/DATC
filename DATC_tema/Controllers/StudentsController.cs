
using AutoMapper;
using DATC_tema.BLL.DTOs;
using DATC_tema.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DATC_tema.Controllers;

[ApiController]
[Route("students")]
public class StudentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IStudentsService _studentsService;

    public StudentsController(IMapper mapper, IStudentsService studentsService)
    {
        _mapper = mapper;
        _studentsService = studentsService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentResponseDTO>>> GetAll()
    {
        var result = await _studentsService.GetAllStudents();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<string>> PostStudent([FromBody] StudentRequestDTO student)
    {
        var result = await _studentsService.PostStudent(student);
        return Ok(result);
    }

    [HttpGet("by-faculty")]
    public async Task<ActionResult<IEnumerable<StudentResponseDTO>>> GetStudentsByFaculty([FromQuery] string faculty)
    {
        var result = await _studentsService.GetStudentcsByFacultyAsync(faculty);
        return Ok(result);
    }

    [HttpGet("count")]
    public async Task<ActionResult<int>> CountStudents()
    {
        return Ok(await _studentsService.CountStudents());
    }
}
