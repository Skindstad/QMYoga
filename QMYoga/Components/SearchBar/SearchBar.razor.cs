using Microsoft.AspNetCore.Components;
using QMYoga.Context;
using QMYoga.Models;

namespace QMYoga.Components.SearchBar
{
    public partial class SearchBar : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QMYogaContext Context { get; set; }

        public List<Tag> AllTags { get; set; } = [];

        [Parameter]
        public List<Tag> DefaultSelectedTags { get; set; } = [];

        public List<Tag> SelectedTags { get; set; } = [];

        public bool TagListVisible { get; set; }
        public Action? OnChanged { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            DefaultSelectedTags ??= [];

        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AllTags = Context.Tags.OrderBy(static t => t.Name).ToList();

            foreach (Tag tag in DefaultSelectedTags)
            {
                Tag? foundTag = AllTags.FirstOrDefault(t => t.Name == tag.Name);
                if (foundTag is not null)
                {
                    SelectedTags.Add(foundTag);
                }
                else
                {
                    Console.WriteLine("Tag not found: " + tag.Name);
                }
            }
        }

        public void Search()
        {
            if (SelectedTags.Count == 0)
            {
                NavigationManager.NavigateTo("/Playlist", true);
                return;
            }

            string queryString = SelectedTags
                .Select(static t => Uri.EscapeDataString(t.Name))
                .Aggregate(static (a, b) => a + "|||" + b);

            NavigationManager.NavigateTo("/Playlist?tags=" + queryString, true);
        }

        public void RemoveTag(Tag tag)
        {
            _ = SelectedTags.Remove(tag);
            OnChanged?.Invoke();
        }

        public void ToggleTagList()
        {
            TagListVisible = !TagListVisible;
        }

        public void ShowTagList()
        {
            TagListVisible = true;
        }

        public void HideTagList()
        {
            TagListVisible = false;
        }

        public void ToggleTag(Tag tag)
        {
            if (!SelectedTags.Remove(tag))
            {
                SelectedTags.Add(tag);
            }
            OnChanged?.Invoke();
        }

        public bool IsSelected(Tag tag)
        {
            return SelectedTags.Contains(tag);
        }
    }
}
