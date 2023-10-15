using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services;

public class MovieServices : IMovieServices
{
    private readonly ApplicationsDbContext _context;
   

    public async Task<IEnumerable<Movie>> GetAll()
    {
        return await _context.Movies.
            OrderByDescending(r=>r.Rate).
            Include(m=>m.Genre).
            ToListAsync();
    }

    public async Task<Movie> Add(Movie movie)
    {
       _context.Movies.AddAsync(movie);
       _context.SaveChanges();
       return movie;
    }

   
    public Movie Update(Movie movie)
    {   
        _context.Movies.Update(movie);
        _context.SaveChanges();
        return movie;
    }

    public Movie Delete(Movie movie)
    {
        
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return movie;
    }

    public async Task<Movie> GetById(int id)
    {
        return await _context.Movies.SingleOrDefaultAsync(m => m.Id == id);
    }
}