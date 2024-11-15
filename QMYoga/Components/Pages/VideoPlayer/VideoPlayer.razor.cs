using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using QMYoga.Context;
using QMYoga.Models;

namespace QMYoga.Components.Pages.VideoPlayer
{
    public partial class VideoPlayer : ComponentBase
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "playlistid")]
        public int PlaylistId { get; set; }

        [Parameter]
        [SupplyParameterFromQuery(Name = "videoid")]
        public int VideoId { get; set; }

        [Inject]
        public QMYogaContext Context { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public Video Video { get; set; }
        public QMYoga.Models.Playlist Playlist { get; set; }

        public bool IsVideoActive { get; set; }
        public Video? PrevVideo { get; set; }
        public Video? NextVideo { get; set; }

        public void ActivateVideo()
        {
            IsVideoActive = true;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Playlist = Context.Playlists
                .Include(static p => p.Videos)
                .Include(static p => p.SubCategory)
                .ToList()
                .FirstOrDefault(p => p.Id == PlaylistId);

            if (Playlist is null)
            {
                return;
            }

            Console.WriteLine("VID: " + VideoId);
            Console.WriteLine("LEN: " + Playlist.Videos.Count);
            Video = Playlist.Videos
                .FirstOrDefault(v => v.Id == VideoId)
                ?? Playlist.Videos.ToList().FirstOrDefault();

            int videoIndex = Playlist.Videos.ToList().IndexOf(Video);
            PrevVideo = videoIndex > 0 ? Playlist.Videos.ToList()[videoIndex - 1] : null;
            NextVideo = videoIndex < Playlist.Videos.Count - 1 ? Playlist.Videos.ToList()[videoIndex + 1] : null;

            IsVideoActive = false;
        }

        public void BackToPlaylists()
        {
            NavigationManager.NavigateTo("/Playlist?subcategory=" + Playlist.SubCategory.Id, true);
        }
    }



}
