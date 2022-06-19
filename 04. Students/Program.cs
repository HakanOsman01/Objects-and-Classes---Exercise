using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student>students= new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <=n; i++)
            {
                string[] studnetArguments = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                string currentStudentFirstName = studnetArguments[0];
                string currentStudentLastName = studnetArguments[1];
                double currentStudentGrade = double.Parse(studnetArguments[2]);
                Student cuurentStudent 
                 = new Student(currentStudentFirstName,
                 currentStudentLastName,currentStudentGrade);
                students.Add(cuurentStudent);
            }
            List<Student> orderList = students
             .OrderByDescending(student => student.Grade).ToList();
            foreach(Student student in orderList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
    class Student
    {
        public Student(string firstName,string lastName,double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

    }
}
