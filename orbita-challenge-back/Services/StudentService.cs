using Data;
using Microsoft.EntityFrameworkCore;
namespace orbita_challenge_back.Services;

public class StudentService : IStudentService
{
    private readonly StudentContext _context;
    
    public StudentService(StudentContext context)
    {
        _context = context;
    }
    
    public async Task<bool> StudentExists(int id)
    {
        return await _context.Students.AnyAsync(e => e.Id == id);
    }
}