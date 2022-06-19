using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Person
    {
        public Person(string name, string Id, int age)
        {
            this.Name = name;
            this.IDNumber = Id;
            this.Age = age;
        }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public int Age { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string[] paramsOfPerson = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
            while(paramsOfPerson[0]!= "End")
            {
                string name = paramsOfPerson[0];
                string Id = paramsOfPerson[1];
                int age = int.Parse(paramsOfPerson[2]);
                bool doesExistPerson = CheckIsPersonExist(persons, Id);
                if (doesExistPerson)
                {
                    Person existingPerson = ChangeAgeAndName(persons, Id);
                    existingPerson.Age = age;
                    existingPerson.Name = name;
                }
                else
                {
                    Person newPerson = new Person(name, Id, age);
                    persons.Add(newPerson);
                }
                paramsOfPerson = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .ToArray();

            }
            List<Person> filterPersons = persons.OrderBy(person => person.Age).ToList();
            foreach(Person person in filterPersons)
            {
                Console.WriteLine($"{person.Name} with ID: {person.IDNumber} is {person.Age} y" +
                    $"ears old.");
            }

        }

         static Person ChangeAgeAndName(List<Person>persons,string Id)
         {
            foreach(Person person in persons)
            {
                if (person.IDNumber == Id)
                {
                    return person;
                }
            }
            return null;
         }

        static bool CheckIsPersonExist(List<Person>persons,string id)
        {
           foreach(Person person in persons)
           {
                if (person.IDNumber == id)
                {
                    return true;
                }
           }
            return false;
        }
    }
    
}
