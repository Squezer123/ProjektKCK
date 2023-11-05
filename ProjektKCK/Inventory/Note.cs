using System;

namespace ProjektKCK
{
    class Note
    {
        public string Title { get; set; }
        public string Content {get; set;}

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }
        public override bool Equals(object obj)
        {
            if (obj is Note otherNote)
            {
                return Title == otherNote.Title && Content == otherNote.Content;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ Content.GetHashCode();
        }
        public void DisplayNote()
        {
            
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Content: {Content}");
        }
    }
}
