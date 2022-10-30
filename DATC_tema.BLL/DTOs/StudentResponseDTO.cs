namespace DATC_tema.BLL.DTOs;

public class StudentResponseDTO
{
    public string University { get; set; } = String.Empty;
    public string Cnp { get; set; } = String.Empty;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Faculty { get; set; }
}
