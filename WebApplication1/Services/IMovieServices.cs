namespace WebApplication1.Services;

public interface IMovieServices
{
    Task<IEnumerable<Movie>> GetAll();
    Task<Movie> Add(Movie movie);
    Movie Update(Movie movie);
    Movie Delete(Movie movie);
    Task<Movie> GetById(int id);
}