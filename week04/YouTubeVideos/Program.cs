using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("C# Course #1", "Benjamin Frank", 456);
        Video video2 = new Video("C# Course #2", "Benjamin Frank", 324);
        Video video3 = new Video("C# Course 3#", "Benjamin Frank", 145);

        video1.AddComment(new Comment("Veronica", "Amazing Video"));
        video1.AddComment(new Comment("Maria", "i didnt understand anything"));
        video1.AddComment(new Comment("Omar", "Why is so hard?"));

        video2.AddComment(new Comment("Omar", "Maybe this time is more easy"));
        video2.AddComment(new Comment("Veronica", "this time was more harder than the last video"));
        video2.AddComment(new Comment("Maria", "i didnt understand anything"));

        video3.AddComment(new Comment("Maria", "i didnt understand anything"));
        video3.AddComment(new Comment("Omar", "I'm going to study other thing"));
        video3.AddComment(new Comment("Veronica", "This is easy, 2 + 2 = 5"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine($"Comments: ");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Author}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}