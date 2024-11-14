using Microsoft.AspNetCore.Components;

namespace QMYoga.Components.SearchBar
{
    public partial class SearchBar : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

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
            AllTags = new List<Tag>()
            {
                new Tag
                {
                    Text = "Tag 1"
                },
                new Tag
                {
                    Text = "Tag 2"
                },
                new Tag
                {
                    Text = "Tag 3"
                },
                new Tag
                {
                    Text = "qwe,sad, reg ?¤#"
                },
                new Tag
                {
                    Text = "Tag 5"
                }
            };

            foreach (Tag tag in DefaultSelectedTags)
            {
                Tag? foundTag = AllTags.FirstOrDefault(t => t.Text == tag.Text);
                if (foundTag is not null)
                {
                    SelectedTags.Add(foundTag);
                }
                else
                {
                    Console.WriteLine("Tag not found: " + tag.Text);
                }
            }
        }

        public void Search()
        {
            string queryString = SelectedTags
                .Select(static t => Uri.EscapeDataString(t.Text))
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

    public class Tag
    {
        public string Text { get; set; }
    }
}
