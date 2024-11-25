using System.ComponentModel.DataAnnotations.Schema;

namespace QMYoga.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool IsVisible { get; set; } = false;
        public string Image { get; set; } = "images/YogaLogo.png";
        public ICollection<Video> Videos { get; set; } = new List<Video>();
        public SubCategory SubCategory { get; set; }

        [NotMapped]
        public List<Tag> Tags { get; set; } = [];
    }
}
