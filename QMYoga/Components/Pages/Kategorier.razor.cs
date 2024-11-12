using Microsoft.AspNetCore.Components;

namespace QMYoga.Components.Pages
{
    public partial class Kategorier : ComponentBase
    {
        public List<Category> Categories { get; set; }

        public Kategorier()
        {
            Categories = [
                new Category
                {
                    Name = "Yoga",
                    SubCategories = [
                        new SubCategory
                        {
                            Name = "Nakke",
                            Url = "nakke",
                            ImagePath = "images/nakke.jpg"
                        },
                        new SubCategory
                        {
                            Name = "Ryg",
                            Url = "ryg",
                            ImagePath = "images/ryg.jpg"
                        },
                        new SubCategory
                        {
                            Name = "Hjerte",
                            Url = "hjerte",
                            ImagePath = "images/hjerte.png"
                        },
                        new SubCategory
                        {
                            Name = "Nakke",
                            Url = "nakke",
                            ImagePath = "images/nakke.jpg"
                        },
                        new SubCategory
                        {
                            Name = "Ryg",
                            Url = "ryg",
                            ImagePath = "images/ryg.jpg"
                        },
                        new SubCategory
                        {
                            Name = "Hjerte",
                            Url = "hjerte",
                            ImagePath = "images/hjerte.png"
                        },
                        new SubCategory
                        {
                            Name = "Nakke",
                            Url = "nakke",
                            ImagePath = "images/nakke.jpg"
                        },
                        new SubCategory
                        {
                            Name = "Ryg",
                            Url = "ryg",
                            ImagePath = "images/ryg.jpg"
                        },
                        new SubCategory
                        {
                            Name = "Hjerte",
                            Url = "hjerte",
                            ImagePath = "images/hjerte.png"
                        },
                        new SubCategory
                        {
                            Name = "Nakke",
                            Url = "nakke",
                            ImagePath = "images/nakke.jpg"
                        },
                        new SubCategory
                        {
                            Name = "Ryg",
                            Url = "ryg",
                            ImagePath = "images/ryg.jpg"
                        },
                        new SubCategory
                        {
                            Name = "Hjerte",
                            Url = "hjerte",
                            ImagePath = "images/hjerte.png"
                        }
                    ]
                },
                new Category
                {
                    Name = "Andet",
                    SubCategories = [
                        new SubCategory
                        {
                            Name = "Meditation",
                            Url = "meditation",
                            ImagePath = "images/meditation.webp"
                        },
                        new SubCategory
                        {
                            Name = "Åndedræt",
                            Url = "åndedræt",
                            ImagePath = "images/åndedræt.jpg"
                        }
                    ]
                }
            ];
        }
    }

    public class Category
    {
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }

    public class SubCategory
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImagePath { get; set; }
    }
}
