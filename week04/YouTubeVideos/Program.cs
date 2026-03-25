using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        //Video 1
        Video v1 = new Video("Hotcakes Recipe", "Pamela", 300);
        v1.AddComment(new VideoComment("Luis", "That looks so good!"));
        v1.AddComment(new VideoComment("Diana", "I'd love to try this."));
        v1.AddComment(new VideoComment("Lisa", "Great video"));
        videos.Add(v1);

        //Video 2
        Video v2 = new Video("C# Tutorial", "Carlos", 500);
        v2.AddComment(new VideoComment("Kim", "Helped me a lot."));
        v2.AddComment(new VideoComment("Carlos", "Very clear explanation."));
        v2.AddComment(new VideoComment("Pam", "Excellent tutorial!"));

        //Video 3
        Video v3 = new Video("Cooking Mole", "Juan", 350);
        v3.AddComment(new VideoComment("Kim", "Thanks for sharing."));
        v3.AddComment(new VideoComment("Jose", "Looks delicious."));
        v2.AddComment(new VideoComment("Peter", "I'll try this recipe!"));

        //Display info
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}

class VideoComment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public VideoComment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<VideoComment> comments = new List<VideoComment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(VideoComment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");

        foreach (var c in comments)
        {
            Console.WriteLine($"- {c.Name}: {c.Text}");
        }
        Console.WriteLine();
    }
}