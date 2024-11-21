using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using QMYoga.Context;
using QMYoga.Models;

namespace QMYoga.Components.Pages.VideoPlayer
{
    public partial class VideoPlayer : ComponentBase
    {
        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }


        public string TagInput { get; set; }
        public bool AddingTags { get; set; }
        [Parameter]
        [SupplyParameterFromQuery(Name = "edit")]
        public bool Editing { get; set; }

        [Parameter]
        [SupplyParameterFromQuery(Name = "create")]
        public bool Creating { get; set; }

        public bool Viewing => !Editing && !Creating;

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

        public void ToggleVideo()
        {
            if (!Viewing)
            {
                IsVideoActive = !IsVideoActive;
            }
        }

        public void DeactivateVideo()
        {
            IsVideoActive = false;
        }


        public void ActivateVideo()
        {
            if (Viewing)
            {
                IsVideoActive = true;
            }
        }

        public void EditVideo()
        {
            NavigationManager.NavigateTo("/videoplayer?playlistid=" + PlaylistId + "&videoid=" + Video.Id + "&edit=true", true);
        }

        public void SaveVideo()
        {
            List<Tag> allTags = Context.Tags.ToList();
            Video.Tags = Video.Tags
                .Select(tag => allTags.Find(t => t.Name == tag.Name) is Tag t ? t : tag).ToList();

            Video.UploadDate = DateTime.Now;

            try
            {
                TagLib.File file = TagLib.File.Create(WebHostEnvironment.WebRootPath + Video.Url);
                TimeSpan duration = file.Properties.Duration;

                Video.Duration = duration;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Context.Update(Video);
            Context.SaveChanges();
            NavigationManager.NavigateTo("/videoplayer?playlistid=" + PlaylistId + "&videoid=" + Video.Id, true);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Playlist = Context.Playlists
                .Include(static p => p.Videos)
                .ThenInclude(static v => v.Tags)
                .Include(static p => p.SubCategory)
                .ToList()
                .FirstOrDefault(p => p.Id == PlaylistId);

            if (Playlist is null)
            {
                return;
            }

            if (Creating)
            {
                Video = new()
                {
                    Thumbnail = "images/YogaLogo.png",
                    PlayList = Playlist,
                };

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

        public void AddTag()
        {
            Video.Tags.Add(new Tag
            {
                Name = TagInput
            });
            TagInput = "";
        }

        public void SaveTags()
        {
            Console.WriteLine("Saving tags");
            HideAddTagPopup();
        }

        public async Task<string?> SaveFile(InputFileChangeEventArgs e)
        {
            if (e.File is null)
            {
                return null;
            }

            using MemoryStream memoryStream = new();
            using Stream stream = e.File.OpenReadStream(maxAllowedSize: 1000 * 1000 * 1000);
            await stream.CopyToAsync(memoryStream);

            string hash = ComputeHash(memoryStream);
            string fileName = "/uploads/" + hash + "_" + e.File.Name;
            string fullName = WebHostEnvironment.WebRootPath + fileName;

            if (!File.Exists(fullName))
            {
                using FileStream fs = File.OpenWrite(fullName);
                memoryStream.Seek(0, SeekOrigin.Begin);
                await CopyStreamAsync(memoryStream, fs);
            }

            return fileName;
        }

        public static string ComputeHash(Stream inputStream)
        {
            // Ensure the stream position is at the beginning
            if (inputStream.CanSeek)
            {
                inputStream.Seek(0, SeekOrigin.Begin);
            }

            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(inputStream);

            // Convert the byte array to a hexadecimal string
            StringBuilder hashString = new();
            foreach (byte b in hashBytes)
            {
                hashString.Append(b.ToString("x2"));
            }

            return hashString.ToString();
        }


        public static async Task CopyStreamAsync(Stream source, Stream destination)
        {
            const int bufferSize = 81920; // 80 KB buffer size
            byte[] buffer = new byte[bufferSize];
            int bytesRead;

            while ((bytesRead = await source.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await destination.WriteAsync(buffer, 0, bytesRead);
            }
        }

        public async Task UploadMediaFile()
        {
            await TriggerFileInput("#input-media");
        }

        public async Task UploadThumbnail()
        {
            await TriggerFileInput("#input-thumb");
        }

        public void RemoveTag(Tag tag)
        {
            Video.Tags.Remove(tag);
        }

        public void ShowAddTagPopup()
        {
            AddingTags = true;
        }

        public void HideAddTagPopup()
        {
            AddingTags = false;
        }

        public async Task NewMediaSelected(InputFileChangeEventArgs e)
        {
            string? fileName = await SaveFile(e);
            if (fileName is null)
            {
                return;
            }
            Video.Url = fileName;
        }

        public async Task NewThumbnailSelected(InputFileChangeEventArgs e)
        {
            string? fileName = await SaveFile(e);
            if (fileName is null)
            {
                return;
            }
            Video.Thumbnail = fileName;
        }

        public void BackToPlaylists()
        {
            NavigationManager.NavigateTo("/Playlist?subcategory=" + Playlist.SubCategory.Id, true);
            
        }

        public async Task TriggerFileInput(string querySelector)
        {
            await JSRuntime.InvokeVoidAsync("eval", "document.querySelector('" + querySelector + "[type=file]').click()");
        }

        public void DeleteVideo()
        {
            Context.Remove(Video);
            Context.SaveChanges();
            NavigationManager.NavigateTo("/videoplayer?playlistid=" + Playlist.Id, true);
        }
    }



}
