namespace BibliotecaMonolito.Models;

public class Instructor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
    public int InstructorId { get; set; }
 public Instructor? instructor { get; set; }
   
}