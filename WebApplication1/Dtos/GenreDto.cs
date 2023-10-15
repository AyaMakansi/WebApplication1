namespace WebApplication1.Dtos;

public class GenreDto
{  
    [MaxLength(100)]
    public string Name { get; set; }
}