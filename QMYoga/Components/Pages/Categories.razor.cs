using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using QMYoga.Context;
using QMYoga.Models;

namespace QMYoga.Components.Pages
{
    public partial class Kategorier : ComponentBase
    {
        [Inject]
        public QMYogaContext Context { get; set; }

        public List<Category> Categories { get; set; }

        private void ReplaceData()
        {
            Context.Categories.ExecuteDelete();
            Context.Categories.Add(new()
            {
                Title = "Yoga",
                SubCategories = [
                new SubCategory
                {
                    Title = "Nakke",
                    Url = "nakke",
                    ImagePath = "images/nakke.jpg"
                },
                new SubCategory
                {
                    Title = "Hjerte",
                    Url = "hjerte",
                    ImagePath = "images/hjerte.png"
                },
                new SubCategory
                {
                    Title = "Ryg",
                    Url = "ryg",
                    ImagePath = "images/ryg.jpg"
                },
                new SubCategory
                {
                    Title = "Nakke",
                    Url = "nakke",
                    ImagePath = "images/nakke.jpg"
                },
                new SubCategory
                {
                    Title = "Hjerte",
                    Url = "hjerte",
                    ImagePath = "images/hjerte.png"
                },
                new SubCategory
                {
                    Title = "Ryg",
                    Url = "ryg",
                    ImagePath = "images/ryg.jpg"
                },
                new SubCategory
                {
                    Title = "Nakke",
                    Url = "nakke",
                    ImagePath = "images/nakke.jpg"
                },
                new SubCategory
                {
                    Title = "Hjerte",
                    Url = "hjerte",
                    ImagePath = "images/hjerte.png"
                },
                new SubCategory
                {
                    Title = "Ryg",
                    Url = "ryg",
                    ImagePath = "images/ryg.jpg"
                },
                new SubCategory
                {
                    Title = "Nakke",
                    Url = "nakke",
                    ImagePath = "images/nakke.jpg"
                },
                new SubCategory
                {
                    Title = "Hjerte",
                    Url = "hjerte",
                    ImagePath = "images/hjerte.png"
                },
                new SubCategory
                {
                    Title = "Ryg",
                    Url = "ryg",
                    ImagePath = "images/ryg.jpg"
                },
                new SubCategory
                {
                    Title = "Nakke",
                    Url = "nakke",
                    ImagePath = "images/nakke.jpg"
                },
                new SubCategory
                {
                    Title = "Hjerte",
                    Url = "hjerte",
                    ImagePath = "images/hjerte.png"
                },
                new SubCategory
                {
                    Title = "Ryg",
                    Url = "ryg",
                    ImagePath = "images/ryg.jpg"
                },
                ]
            });

            Context.Categories.Add(new()
            {
                Title = "Andet",
                SubCategories = [
                new SubCategory
                {
                    Title = "Meditation",
                    Url = "meditation",
                    ImagePath = "images/meditation.webp"
                },
                new SubCategory
                {
                    Title = "Åndedræt",
                    Url = "åndedræt",
                    ImagePath = "images/åndedræt.jpg"
                },
                ]
            });
            Context.SaveChanges();
        }

        protected override void OnInitialized()
        {
            //ReplaceData();
            Categories = Context.Categories.Include(static c => c.SubCategories).ToList();
        }
    }

}
