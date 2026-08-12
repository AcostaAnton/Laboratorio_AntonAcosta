using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaMonolito.Models;

namespace BibliotecaMonolito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructorController : ControllerBase
{
    private readonly LibraryDbContext _db;

    public InstructorController(LibraryDbContext db) => _db = db;

    [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var instructores = await _db.Instructores.ToListAsync();
            return Ok(instructores);
    }
   



    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var instructor = await _db.Instructores.FindAsync(id);
        if (instructor is null) return NotFound();
        return Ok(instructor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Instructor instructor)
    {
        // Validación de negocio directamente aquí (monolítico a propósito)
        if (string.IsNullOrWhiteSpace(instructor.Nombre))
            return BadRequest("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(instructor.Especialidad))
            return BadRequest("La especialidad es obligatoria.");

        var instructorExiste = await _db.Instructores.AnyAsync(i => i.Id == instructor.Id);
        if (!instructorExiste) return BadRequest("El instructor especificado no existe.");

        _db.Instructores.Add(instructor);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = instructor.Id }, instructor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Instructor instructorActualizado)
    {
        var instructor = await _db.Instructores.FindAsync(id);
        if (instructor is null) return NotFound();

        instructor.Nombre = instructorActualizado.Nombre;
        instructor.Especialidad = instructorActualizado.Especialidad;
        instructor.InstructorId = instructorActualizado.InstructorId;

        await _db.SaveChangesAsync();
        return Ok(instructor);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var instructor = await _db.Instructores.FindAsync(id);
        if (instructor is null) return NotFound();

        _db.Instructores.Remove(instructor);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
