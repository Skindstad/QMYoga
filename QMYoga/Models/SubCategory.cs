namespace QMYoga.Models;

public class SubCategory
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string Url { get; set; }
    public Category Category { get; set; }
    public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
