using Microsoft.AspNetCore.Components;
using QMYoga.Context;
using QMYoga.Models;

namespace QMYoga.Components.Pages
{
    public partial class Kategorier : ComponentBase
    {
        [Inject]
        public QMYogaContext Context { get; set; }

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

            Context.Categories.AddRange(Categories.ToArray());
            Context.SaveChanges();

        }
    }

}
