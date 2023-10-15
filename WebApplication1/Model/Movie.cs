using WebApplication1.Model;

public class Movie
{
    public int Id { get; set; }
    [MaxLength(250)]
    public string Title { get; set; }
    public int Year { get; set; }
   
    public byte[] Poster { get; set; }
    public int Rate { get; set; }
    [MaxLength(2500)]
    public string Storeline { get; set; }
   
    public int GenreId { get; set; }
    
    public Genre Genre { get; set; }
}