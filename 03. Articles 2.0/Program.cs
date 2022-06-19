using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{this.Title.Trim()} - {this.Content.Trim()}: {this.Author.Trim()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int numberOfArticles = int.Parse(Console.ReadLine());
            for(int curArticle = 1; curArticle <= numberOfArticles; curArticle++)
            {
                string[] curArticleParams = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
                string title = curArticleParams[0];
                string content = curArticleParams[1];
                string author = curArticleParams[2];
                Article newArticle = new Article()
                {
                    Title = title,
                    Content = content,
                    Author = author

                };
                articles.Add(newArticle);
            }
            string type = Console.ReadLine();
            foreach(Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
}
