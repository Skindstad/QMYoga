using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QMYoga.Models
{
    public class Video
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremented ID
        public int Id { get; set; }

        [Required] // Ensures this field is not nullable in the DB
        [MaxLength(200)] // Sets a max length of 200 characters for Title
        public string Title { get; set; }

        [MaxLength(1000)] // Max length for description, optional
        public string Description { get; set; }

        [Required]
        [Url] // Ensures the URL is valid, optional validation attribute
        public string Url { get; set; }

        [Required]
        public TimeSpan Duration { get; set; } // Stores the length of the video

        [Required]
        public DateTime UploadDate { get; set; } // The date the video was uploaded
        
        public int PlayListID { get; set; } // Sets an id to a playlist ID, is null if not part of a list
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
