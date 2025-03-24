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
            string[] studentNames = new string[10];  // Array for names
            int[] studentAges = new int[10];        // Array for ages
            double[] studentMarks = new double[10]; // Array for marks
            try
            {
                if (studentCount >= studentNames.Length)// n=10 starts from 0 to 9 so if the student count is greater than or equal to the length of the array then the array is full
                {
                    Console.WriteLine("Error: Student list is full. Cannot add more students.");
                    return;
                }

                Console.Write("Enter Student Name: ");
                studentNames[studentCount] = Console.ReadLine();

                int age;
                Console.Write("Enter Student Age: ");
                string ageInput = Console.ReadLine();
                try
                {
                    age = Convert.ToInt32(ageInput); // Try to convert the age to an integer
                    if (age <= 0)
                    {
                        throw new Exception("Age must be greater than 0.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}. Please enter a valid age.");
                    return;
                }
                studentAges[studentCount] = age;

                double marks;
                Console.Write("Enter Student Marks: ");
                string marksInput = Console.ReadLine();
                try
                {
                    marks = Convert.ToDouble(marksInput); // Try to convert the marks to a double
                    if (marks < 0 || marks > 100)
                    {
                        Console.WriteLine("Marks must be between 0 and 100.");// if the marks are not between 0 and 100 then it will throw an exception due to the logic applied.
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}. Please enter valid marks.");
                    return;
                }
                studentMarks[studentCount] = marks;

                studentCount++; //for incrementation of the student count after adding a student
                Console.WriteLine("Student added successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
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
            try
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

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: Accessing out-of-bounds index in marks array.");
            }

        }

        static void CalculateClassAverage()
        {
            try
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
            catch (FormatException e)//exception for numbers only!
            {
                Console.WriteLine("enter only numbers!");
            }
            catch (DivideByZeroException)//exception for divide by zero, int cant be divided by zero.
            {
                Console.WriteLine("Error: Cannot divide by zero.");
            }
            catch (Exception e)//for any input error occured
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }

            Console.ReadKey();//to hold the console window and to read the corrrect mathematical equetion value .
        }

        static void SortStudentsByMarks()
        {
            try
            {
                for (int i = 0; i < studentCount - 1; i++) // i starts from 0 till (n-1)
                {
                    for (int j = i + 1; j < studentCount; j++) // j starts after i till n (end of the list)
                    {
                        if (marks[i] < marks[j]) // If the i-th student has smaller marks than the j-th student (swapping the values)
                        {
                            Swap(ref marks[i], ref marks[j]);
                            Swap(ref names[i], ref names[j]);
                            Swap(ref ages[i], ref ages[j]);
                            Swap(ref enrollmentDate[i], ref enrollmentDate[j]);
                        }

                        // Skip to the next iteration if marks[i] is greater than marks[j]
                        else if (marks[i] > marks[j])
                        {
                            continue;  // Skip this iteration and move to the next value of j
                        }
                    }
                }
                Console.WriteLine("Students sorted by marks in descending order.");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: An index was out of range. Please check the array bounds.");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Error: One of the arrays is null. Please initialize the arrays properly.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }



        }


        static void FindTopPerformingStudent()
        {
            try
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
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: An index was out of range. Please check the array bounds.");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Error: One of the arrays is null. Please initialize the arrays properly.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }
        }
        static void FindTopPerformingStudent2()
        {
        }

            static void DeleteStudent()
            {
                Console.Write("Enter student name to delete: ");
                string deleteName = Console.ReadLine().ToLower();
                bool found = false;

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
                        found = true;
                        Console.WriteLine("Student deleted successfully...");
                        break;//exit loop
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

