namespace orbita_challenge_back.Services;

public interface IStudentService
{
    Task<bool> StudentExists(int id);
}