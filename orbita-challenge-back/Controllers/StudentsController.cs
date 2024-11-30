using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;
using orbita_challenge_back.Services;

namespace orbita_challenge_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentContext _context;
    private readonly IStudentService _studentService;

    public StudentsController(StudentContext context, IStudentService studentService)
    {
        _context = context;
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        return await _context.Students.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return student;
    }

    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutStudent(int id, Student student)
    {
        if (id != student.Id)
        {
            return BadRequest(
                new
                {
                    error = "Id do estudante não corresponde!",
                    field = "id"
                }
            );
        }

        var existingStudent = await _context.Students.FindAsync(id);
        if (existingStudent == null)
        {
            return NotFound();
        }

        if (existingStudent.AcademicRegister != student.AcademicRegister)
        {
            return BadRequest(new
            {
                error = "Registro Academico não pode ser alterado!",
                field = "academicRegister"
            });
        }
        
        if (existingStudent.Cpf != student.Cpf)
        {
            return BadRequest(new
            {
                error = "Cpf não pode ser alterado!",
                field = "cpf"
            });
        }

        _context.Entry(existingStudent).CurrentValues.SetValues(student);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _studentService.StudentExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return Ok(
            new
            {
                message = "Estudante atualizado com sucesso!",
                student
            }
        );
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return Ok(
            new
            {
                message = "Estudante removido com sucesso!",
            }
        );
    }

    [HttpGet("test")]
    public string Test()
    {
        return "Hello World!";
    }
}