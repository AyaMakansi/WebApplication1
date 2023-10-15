
using Microsoft.AspNetCore.Mvc;

using WebApplication1.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]

public class GenresController :ControllerBase
{
    private readonly IGenreServices _genreServices;

   
    public GenresController(IGenreServices genreServices)
    {
        _genreServices = genreServices;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(GenreDto dto)
    {
        var genres = _genreServices.GetAll();
        return Ok(genres);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id,GenreDto dto)
    {
        var genre =  _genreServices.GetById(id);
        return Ok(genre);
    }
   
    [HttpPost]
    public async Task<IActionResult> AddAsync(GenreDto dto)
    { var genre = new Genre { Name = dto.Name };
        _genreServices.Add(genre);
        return Ok(genre);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] GenreDto dto)
    {
        var genre = await _genreServices.GetById(id);
        if (genre==null)
        {
            return NotFound($"No genre was found with ID: {id}");
        }

        genre.Name = dto.Name;
        _genreServices.Update(genre);
        return Ok(genre);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id, [FromBody] GenreDto dto)
    {
        var genre = await _genreServices.GetById(id);
        if (genre==null)
        {
            return NotFound($"No genre was found with ID: {id}");
        }

        genre.Name = dto.Name;
        _genreServices.Delete(genre);
        return Ok(genre);
    }
}