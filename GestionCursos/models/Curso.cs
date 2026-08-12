namespace BibliotecaMonolito.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int CreditosAcedemicos { get; set; }
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
    }
}
