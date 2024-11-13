namespace QMYoga.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; } = false;
        public ICollection<Image> Images { get; set; } = new List<Image>();

    }
}
