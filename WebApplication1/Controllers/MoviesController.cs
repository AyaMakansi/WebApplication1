
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController :ControllerBase
{
    private readonly IMovieServices _movieServices;
 private new List<string> _allowedExtentions = new List<string> { ".png", ".jpg" };
    private long _maxAllowedPosterSize = 1048576;//1MB
    
    public MoviesController(IMovieServices movieServices)
    {
        _movieServices = movieServices;
    } 
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllAsync()
    {
        var movies = _movieServices.GetAll();
        return Ok(movies);
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromForm] MovieDto dto)
    {  
        if(!_allowedExtentions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
            return BadRequest("Only .png and .jpg images are allowed!");
        if(dto.Poster.Length > _maxAllowedPosterSize)
            return BadRequest("max allowed size for poster is 1MB!");
        
        using var dataStream = new MemoryStream();
        await dto.Poster.CopyToAsync(dataStream);
        var movie = new Movie
        {
            Title = dto.Title,
            Year = dto.Year,
            Poster = dataStream.ToArray(),
            Rate = dto.Rate,
            Storeline = dto.Storeline,
            GenreId = dto.GenreId,
        };
        _movieServices.Add(movie);
        return Ok(movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromForm] MovieDto dto, int id)
    {
        
        
        if(!_allowedExtentions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
            return BadRequest("Only .png and .jpg images are allowed!");
        if(dto.Poster.Length > _maxAllowedPosterSize)
            return BadRequest("max allowed size for poster is 1MB!");
        
        using var dataStream = new MemoryStream();
        await dto.Poster.CopyToAsync(dataStream);
      var movie = await _movieServices.GetById(id);
             if (movie==null)
             {
                 return NotFound($"No Movie ID:{id}");
             }

             movie.Title = dto.Title;
             movie.Year = dto.Year;
             movie.Poster =dataStream.ToArray() ;
             movie.Rate = dto.Rate;
             movie.Storeline = dto.Storeline;
             movie.GenreId = dto.GenreId;
             _movieServices.Update(movie);
             return Ok(movie);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var movie = await _movieServices.GetById(id);
        if (movie==null)
        {
            return NotFound($"No Movie ID:{id}");
        }
        
        _movieServices.Delete(movie);
        return Ok(movie);
    }
}