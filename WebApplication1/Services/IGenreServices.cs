

namespace WebApplication1.Services;

public interface IGenreServices
{
    Task<IEnumerable<Genre>> GetAll();
    Task<Genre> Add(Genre genre);
    Genre Update(Genre genre);
    Genre Delete(Genre genre);
    Task<Genre> GetById(int id);

}