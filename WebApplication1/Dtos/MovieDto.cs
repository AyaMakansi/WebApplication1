namespace WebApplication1.Dtos;

public class MovieDto
{
    [MaxLength(250)]
    public string Title { get; set; }
    public int Year { get; set; }
    
    public IFormFile Poster { get; set; }
    public int Rate { get; set; }
    [MaxLength(2500)]   
    public string Storeline { get; set; }
    
    public int GenreId { get; set; }
   
}