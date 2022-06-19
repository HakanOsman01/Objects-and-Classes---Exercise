using System;
using System.Linq;

namespace _02._Articles
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article(string title,string content,string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public void Edit(string content)
        {
            this.Content = content;
        }
        public void ChangeAuthor(string author)
        {
            this.Author = author;
        } 
        public void Rename(string title)
        {
            this.Title = title;
        }
       public override string ToString()
       {
            return $"{this.Title.Trim()} - {this.Content.Trim()}: {this.Author.Trim()}";
       }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
            string title = cmdArgs[0];
            string content = cmdArgs[1];
            string author = cmdArgs[2];
            Article article = new Article(title, content, author);
            int numberOfCommands = int.Parse(Console.ReadLine());
            for(int i = 1; i <= numberOfCommands; i++)
            {
                //•	"Edit: {new content}"
                //•	"ChangeAuthor: {new author}"
                //•	"Rename: {new title}"
                string[] commnadParameturs = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                string action = commnadParameturs[0];
                if (action == "Edit")
                {
                    string newContent = commnadParameturs[1];
                    article.Edit(newContent);
                }else if(action== "ChangeAuthor")
                {
                    string newAuthor = commnadParameturs[1];
                    article.ChangeAuthor(newAuthor);
                }else if (action == "Rename")
                {
                    string newTitle = commnadParameturs[1];
                    article.Rename(newTitle);
                }
                
            }

            Console.WriteLine(article);
        }
        
    }
   
}
