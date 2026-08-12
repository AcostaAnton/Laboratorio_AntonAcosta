using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaMonolito.Models;

namespace BibliotecaMonolito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructoresController : ControllerBase
{
    private readonly LibraryDbContext _db;

    public InstructoresController(LibraryDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var instructor = await _db.Instructores.ToListAsync();
        return Ok(instructor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Instructor instructor)
    {
        // Lógica de negocio mezclada directamente en el controlador (a propósito)
        if (string.IsNullOrWhiteSpace(instructor.Nombre))
            return BadRequest("El nombre del autor es obligatorio.");

        _db.Instructores.Add(instructor);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = instructor.Id }, instructor);
    }
}
