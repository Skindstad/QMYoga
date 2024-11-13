using Microsoft.AspNetCore.Components;

namespace QMYoga.Components.Pages.VideoPlayer
{
    public partial class VideoPlayer : ComponentBase
    {
        public bool IsVideoActive { get; set; }
        public Video Video { get; set; } = new()
        {
            Title = "Video Title",
            Url = "videos/ben123.mp4",
            Tags = [
                "Tag 1",
                "Tag 2",
                "Tag 3",
                "Tag 4",
            ],
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas nec maximus nibh. Nunc tellus mauris, eleifend vitae maximus ut, euismod sit amet elit. Duis vel nulla purus. Curabitur ultricies pellentesque dictum. Phasellus varius auctor augue, eu interdum lorem suscipit id. Aenean at venenatis neque. In hac habitasse platea dictumst. Vivamus aliquet, enim ut dapibus consequat, turpis sapien porttitor est, sed porttitor tortor lacus in enim. Aenean arcu quam, faucibus rhoncus magna et, vestibulum lacinia metus. Nunc vulputate et ex sed dapibus. Donec cursus vestibulum nisl at eleifend. Suspendisse potenti. Proin aliquam dictum placerat. Quisque molestie ante quis erat rutrum laoreet.",
            PrevVideoImageUrl = "images/ryg.jpg",
            NextVideoImageUrl = "images/nakke.jpg",
            ThumbnailUrl = "images/hjerte.png",
            PrevVideoUrl = "prev_video",
            NextVideoUrl = "next_video"
        };

        public void ActivateVideo()
        {
            IsVideoActive = true;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public string PrevVideoImageUrl { get; set; }
        public string NextVideoImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string PrevVideoUrl { get; set; }
        public string NextVideoUrl { get; set; }
    }
}
