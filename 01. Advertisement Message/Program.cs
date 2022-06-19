﻿using System;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phares = new string[]
           {
               "Excellent product.",
               "Such a great product.",
               "I always use that product.",
               "Best product of its category.",
               "Exceptional product.",
               "I can’t live without this product."

           };
            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles.",
                "I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"

            };
            string[] authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };
            string[] cities = new string[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"

            };
            Random random = new Random();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int nextPhares = random.Next(0, phares.Length);
                int nextEvent = random.Next(0, events.Length);
                int nextAuthor = random.Next(0, authors.Length);
                int nextCity = random.Next(0, cities.Length);
                Console.WriteLine($"{phares[nextPhares]} {events[nextEvent]} " +
                    $"{authors[nextAuthor]} – {cities[nextCity]}.");
            }

        }
    }
}