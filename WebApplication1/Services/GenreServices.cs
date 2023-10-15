using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Services;

public class GenreServices :IGenreServices
{
    private readonly ApplicationsDbContext _context;
    public async Task<IEnumerable<Genre>> GetAll()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<Genre> Add(Genre genre)
    {
         await _context.AddAsync(genre);
         _context.SaveChanges();
         return genre;

    }

    public Genre  Update(Genre genre)
    {
         _context.Update(genre);
        _context.SaveChanges();
        return genre;
    }

    public Genre Delete(Genre genre)
    {
        _context.Remove(genre);
        _context.SaveChanges();
        return genre;
    }

    public async Task<Genre> GetById(int id)
    {
        return await _context.Genres.SingleOrDefaultAsync(g => g.Id == id);
    }
}