using System;

namespace StudentManagementSystem
{
    class Program
    {
        const int MAX_STUDENTS = 100;
        static string[] names = new string[MAX_STUDENTS];
        static int[] ages = new int[MAX_STUDENTS];
        static double[] marks = new double[MAX_STUDENTS];
        static DateTime[] enrollmentDate = new DateTime[MAX_STUDENTS];
        static int studentCount = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add a New Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Search for a Student by Name");
                Console.WriteLine("4. Calculate the Class Average");
                Console.WriteLine("5. Sort Students by Marks and Find Top-Performing Student");
                Console.WriteLine("6. Delete a Student");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

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
                        SortStudentsByMarks();
                        FindTopPerformingStudent();
                        break;
                    case "6":
                        DeleteStudent();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            if (studentCount >= MAX_STUDENTS)
            {
                Console.WriteLine("Cannot add more students. Maximum limit reached.");
                return;
            }

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            int age;
            while (true)
            {
                Console.Write("Enter student age (must be > 21): ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 21)
                    break;
                Console.WriteLine("Invalid age. Please try again.");
            }

            double mark;
            while (true)
            {
                Console.Write("Enter student marks (0-100): ");
                if (double.TryParse(Console.ReadLine(), out mark) && mark >= 0 && mark <= 100)
                    break;
                Console.WriteLine("Invalid marks. Please try again.");
            }

            names[studentCount] = name;
            ages[studentCount] = age;
            marks[studentCount] = mark;
            enrollmentDate[studentCount] = DateTime.Now;
            studentCount++;
        }

        static void ViewAllStudents()
        {
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine($"Name: {names[i]}, Age: {ages[i]}, Marks: {marks[i]}, Enrollment Date: {enrollmentDate[i]}");
            }
        }

        static void FindStudentByName()
        {
            Console.Write("Enter student name to search: ");
            string searchName = Console.ReadLine().ToLower();

            for (int i = 0; i < studentCount; i++)
            {
                if (names[i].ToLower() == searchName)
                {
                    Console.WriteLine($"Name: {names[i]}, Age: {ages[i]}, Marks: {marks[i]}, Enrollment Date: {enrollmentDate[i]}");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }

        static void CalculateClassAverage()
        {
            if (studentCount == 0)
            {
                Console.WriteLine("No students to calculate average.");
                return;
            }

            double totalMarks = 0;
            for (int i = 0; i < studentCount; i++)
            {
                totalMarks += marks[i];
            }

            double average = totalMarks / studentCount;
            Console.WriteLine($"Class Average: {Math.Round(average, 2)}");
        }

        static void SortStudentsByMarks()
        {
            for (int i = 0; i < studentCount - 1; i++)
            {
                for (int j = i + 1; j < studentCount; j++)
                {
                    if (marks[i] < marks[j])
                    {
                        Swap(ref marks[i], ref marks[j]);
                        Swap(ref names[i], ref names[j]);
                        Swap(ref ages[i], ref ages[j]);
                        Swap(ref enrollmentDate[i], ref enrollmentDate[j]);
                    }
                }
            }
            Console.WriteLine("Students sorted by marks in descending order.");
        }

        static void FindTopPerformingStudent()
        {
            if (studentCount == 0)
            {
                Console.WriteLine("No students available...");
                return;
            }

            int topS = 0;// assuming that the first student has the highest marks
            for (int i = 1; i < studentCount; i++)//loops starts from 1 because the top index is set to 0 SO THAT WE CAN COMPARE THE REST OF THE STUDENTS WITH THE FIRST STUDENT!
            {
                if (marks[i] > marks[topS]) //MARKS OF THE CURRENT STUDENT IS GREATER THAN THE MARKS OF THE TOP STUDENT....
                {
                    topS = i;//TOP STUDENT NOW IS AT THE INDEX OF THE CURRENT STUDENT
                }
            }

            Console.WriteLine($"Top-Performing Student: Name: {names[topS]}, Age: {ages[topS]}, Marks: {marks[topS]}, Enrollment Date: {enrollmentDate[topS]}");
        }

        static void DeleteStudent()
        {
            Console.Write("Enter student name to delete: ");
            string deleteName = Console.ReadLine().ToLower();

            for (int i = 0; i < studentCount; i++)
            {
                if (names[i].ToLower() == deleteName)
                {
                    for (int j = i; j < studentCount - 1; j++)
                    {
                        names[j] = names[j + 1];
                        ages[j] = ages[j + 1];
                        marks[j] = marks[j + 1];
                        enrollmentDate[j] = enrollmentDate[j + 1];
                    }
                    studentCount--;
                    Console.WriteLine("Student deleted successfully...");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
