using Microsoft.EntityFrameworkCore;
using QMYoga.Context;
using QMYoga.Models;

namespace QMYoga;

public class DbSeeder
{
    public QMYogaContext Context { get; }
    public DbSeeder(QMYogaContext context)
    {
        Context = context;
    }

    public void InitData()
    {
        Context.Videos.ExecuteDelete();
        Context.Playlists.ExecuteDelete();
        Context.Categories.ExecuteDelete();
        Context.Tags.ExecuteDelete();

        Tag[] tags = [
            new Tag
            {
                Name = "Tag 1"
            },
            new Tag
            {
                Name = "Tag 2"
            },
            new Tag
            {
                Name = "Tag 3"
            },
            new Tag
            {
                Name = "qwe,sad, reg ?¤#"
            },
            new Tag
            {
                Name = "Tag 5"
            }
        ];

        Context.Tags.AddRange(tags);
        Context.SaveChanges();

        tags = Context.Tags.ToArray();

        Category[] categories = [
            new Category
            {
                Title = "Yoga",
                      SubCategories = [
                          new SubCategory
                          {
                              Title = "Blid Hatha",
                              Url = "nakke",
                              ImagePath = "images/category/blid_hatha.jpg"
                          },
                      new SubCategory
                      {
                          Title = "Dynamisk Hatha",
                          Url = "hjerte",
                          ImagePath = "images/category/dynamisk_hatha.jpg"
                      },
                      new SubCategory
                      {
                          Title = "Yin yoga",
                          Url = "ryg",
                          ImagePath = "images/category/yin.jpg"
                      },
                      new SubCategory
                      {
                          Title = "Meditation og Afspænding",
                          Url = "hjerte",
                          ImagePath = "images/category/meditation.jpg"
                      },
                      new SubCategory
                      {
                          Title = "Åndedrætsteknik",
                          Url = "hjerte",
                          ImagePath = "images/category/åndedræt.jpg"
                      }
                      ]
            }
        ];

        Context.Categories.AddRange(categories);
        Context.SaveChanges();

        SubCategory[] subCategories = Context.SubCategories.ToArray();

        Playlist[] playlists = [
            new Playlist
            {
                Name = "Playlist 1.1",
                Description = "Description for playlist 1.1",
                Date = DateTime.Now,
                Image = "images/ryg.jpg",
                SubCategory = subCategories[0]
            },
            new Playlist
            {
                Name = "Playlist 1.2",
                Description = "Description for playlist 1.2",
                Date = DateTime.Now,
                Image = "images/nakke.jpg",
                SubCategory = subCategories[0]
            },
            new Playlist
            {
                Name = "Playlist 1.3",
                Description = "Description for playlist 1.3",
                Date = DateTime.Now,
                Image = "images/hjerte.png",
                SubCategory = subCategories[0]
            },
            new Playlist
            {
                Name = "Playlist 2.1",
                Description = "Description for playlist 2.1",
                Date = DateTime.Now,
                Image = "images/meditation.webp",
                SubCategory = subCategories[1]
            },
            new Playlist
            {
                Name = "Playlist 2.2",
                Description = "Description for playlist 2.2",
                Date = DateTime.Now,
                Image = "images/åndedræt.jpg",
                SubCategory = subCategories[1]
            }
        ];

        Context.Playlists.AddRange(playlists);
        Context.SaveChanges();

        playlists = Context.Playlists.ToArray();

        Video[] videos = [
            new Video
            {
                Title="Video 1.1.1",
                Description="Description for video 1.1.1",
                Url="videos/ben123.mp4",
                Thumbnail="images/ryg.jpg",
                Duration=TimeSpan.FromSeconds(30),
                UploadDate=DateTime.Now,
                PlayList=playlists[0],
                Tags = [tags[0], tags[1], tags[2]]
            },
            new Video
            {
                Title="Video 1.1.2",
                Description="Description for video 1.1.2",
                Url="audio/Godmorgen.mp3",
                Thumbnail="images/ryg.jpg",
                Duration=TimeSpan.FromSeconds(30),
                UploadDate=DateTime.Now,
                PlayList=playlists[0],
                Tags = [tags[3], tags[4]]
            },
            new Video
            {
                Title="Video 1.1.3",
                Description="Description for video 1.1.3",
                Url="videos/ben123.mp4",
                Thumbnail="images/ryg.jpg",
                Duration=TimeSpan.FromSeconds(30),
                UploadDate=DateTime.Now,
                PlayList=playlists[0],
                Tags = [tags[0], tags[1], tags[4]]
            },
            new Video
            {
                Title="Video 1.2.1",
                Description="Description for video 1.2.1",
                Url="videos/ben123.mp4",
                Thumbnail="images/ryg.jpg",
                Duration=TimeSpan.FromSeconds(30),
                UploadDate=DateTime.Now,
                PlayList=playlists[1],
                Tags = [tags[3], tags[1], tags[2]]
            },
        ];

        Context.Videos.AddRange(videos);
        Context.SaveChanges();
    }
}
