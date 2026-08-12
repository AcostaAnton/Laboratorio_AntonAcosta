using Microsoft.EntityFrameworkCore;
using BibliotecaMonolito.Models;


namespace BibliotecaMonolito;

public class LibraryDbContext: DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options): base(options){}

    
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Instructor> Instructores => Set<Instructor>();
}