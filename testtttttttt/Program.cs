using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Student Management System");
                Console.WriteLine("1. Add a new student record");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Find a student by name");
                Console.WriteLine("4. Calculate the class average");
                Console.WriteLine("5. Find the top-performing student");
                Console.WriteLine("6. Sort students by marks");
                Console.WriteLine("7. Delete a student record");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ViewAllStudents();
                        break;
                    case "3":
                        FindStudentByName();
                        break;
                    case "4":
                        CalculateClassAverage();
                        break;
                    case "5":
                        FindTopPerformingStudent();
                        break;
                    case "6":
                        SortStudentsByMarks();
                        break;
                    case "7":
                        DeleteStudentRecord();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter student marks: ");
            double marks = double.Parse(Console.ReadLine());

            students.Add(new Student { Name = name, Age = age, Marks = marks });
            Console.WriteLine("Student added successfully.");
        }

        static void ViewAllStudents()
        {
            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Marks: {student.Marks}");
            }
        }

        static void FindStudentByName()
        {
            Console.Write("Enter student name to search: ");
            string name = Console.ReadLine().ToLower();
            var student = students.FirstOrDefault(s => s.Name.ToLower() == name);

            if (student != null)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Marks: {student.Marks}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void CalculateClassAverage()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available to calculate average.");
                return;
            }

            double average = students.Average(s => s.Marks);
            Console.WriteLine($"Class Average: {Math.Round(average, 2)}");
        }

        static void FindTopPerformingStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available to find top performer.");
                return;
            }

            var topStudent = students.OrderByDescending(s => s.Marks).First();
            Console.WriteLine($"Top Performing Student: Name: {topStudent.Name}, Age: {topStudent.Age}, Marks: {topStudent.Marks}");
        }

        static void SortStudentsByMarks()
        {
            students = students.OrderByDescending(s => s.Marks).ToList();
            Console.WriteLine("Students sorted by marks.");
        }

        static void DeleteStudentRecord()
        {
            Console.Write("Enter student name to delete: ");
            string name = Console.ReadLine().ToLower();
            var student = students.FirstOrDefault(s => s.Name.ToLower() == name);

            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Marks { get; set; } /// i got this from the internet (USED CHATGPT)..
    }
}
