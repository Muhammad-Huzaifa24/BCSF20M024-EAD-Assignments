using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;


// BCSF20M024
// Muhammad Huzaifa Khawar
internal class Program
{
    private static void Main(string[] args)
    {
    // ________________________Optional Argeuments Part

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("*************** ( Optional Argeuments ) ***************");
        Console.ResetColor();

     // Task a implemenation
        Console.ForegroundColor= ConsoleColor.Yellow;
        Console.WriteLine("\n-- Task a");
        Console.ResetColor();

        Console.Write("With default values: ");
        Greet(); // default values
        Console.Write("With custom  values: ");
        Greet("Hi", "huzaifa"); // Custom values

     // Task b implemenation
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n-- Task b");
        Console.ResetColor();

        double area1 = CalculateArea(43.3, 10.4); // custom
        double area2 = CalculateArea(); // optional
        Console.WriteLine($"Custom   Values to calculate area {area1}");
        Console.WriteLine($"Optional Values to calculate area {area2}");

     // Task c implemenation
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n-- Task c");
        Console.ResetColor();

        int twoParamter = AddNumbers(56, 43); // calling with two paramters
        Console.WriteLine($"Two paramters              {twoParamter}");

        int threeParamter = AddNumbers(89, 100, 43); // calling with three paramters
        Console.WriteLine($"Three paramters            {threeParamter}");

        int optionalParamter = AddNumbers(2, 4, optional: 10); // calling with explicit optional keyword
        Console.WriteLine($"Explicit Optional Paramter {optionalParamter}");

     // Task d implemenation
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n-- Task d");
        Console.ResetColor();

        Book defaultObject = new("English");
        Book customObject = new("English", "William David");

        Console.WriteLine("<>- Object  Call with Default Values");
        Console.WriteLine($"Title: {defaultObject.Title}  Author: {defaultObject.Author}");
        Console.WriteLine("\n<>- Object  Call with Custom   Values");
        Console.WriteLine($"Title: {customObject.Title}  Author: {customObject.Author}");


     // __________________________Generics Part

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n******************** ( Generics ) ********************");
        Console.ResetColor();

     // Task a implemenation
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n-- Task a");
        Console.ResetColor();

        MyList<int> list = new();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("<> Adding items to list . . .");
        Console.ResetColor();
        list.AddItem(1);
        list.AddItem(2);
        list.AddItem(3);
        list.AddItem(4);
        list.AddItem(5);

        Console.Write("<> Displaying List Items: ");
        list.DisplayList();

        bool isRemoved = false;
        string? removedElement = null; // Initialize removedElement

        Console.WriteLine("\nWhich element to Remove?");
        do
        {
            try
            {
                removedElement = Console.ReadLine();
                if (string.IsNullOrEmpty(removedElement))
                {
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong input! Please enter a valid integer.");
                    Console.ResetColor();
                    continue;
                }
                isRemoved = list.RemoveItem(int.Parse(removedElement));
                if  (isRemoved) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("<> Removing . . .");
                    Console.ResetColor();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("oh! element not found\nRemove again . . .?");
                    Console.ResetColor();
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Wrong input! Please enter a valid integer.");
                Console.ResetColor();
                //isRemoved = false; // Initialize isRemoved in case of exception
            }
        } while (string.IsNullOrEmpty(removedElement) || (!isRemoved));


        Console.Write("<> Displaying List Items: ");
        list.DisplayList();

     // Task b implemenation
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n-- Task b");
        Console.ResetColor();

        int num1 = 10, num2 = 24;
        string str1 = "Lenovo", str2 = "KenWood";
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("testing with integar and string values . . .");
        Console.ResetColor();

        Console.WriteLine("<> Before Swapping");
        Console.WriteLine($"num1: {num1} | num2: {num2}");
        Console.WriteLine($"str1: {str1} | str2: {str2}");

        Swap(ref num1, ref num2); 

        Console.WriteLine("\n<> After Swapping");
        Console.WriteLine($"num1: {num1} | num2: {num2}");
        Console.WriteLine($"str1: {str1} | str2: {str2}");

     // Task c Method calling
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n-- Task c");
        Console.ResetColor();

        int[] intArray = { 1, 2, 3, 4, 5 };
        double[] doubleArray = { 1.4, 5.6, 7.8, 5, 6 };
        long[] longArray = { 1000, 5000, 7000, 5600, 6099 };
        string[] str = { "hell", "khawar" };

        ComputeSum(intArray);
        ComputeSum(doubleArray);
        ComputeSum(longArray);
        //ComputeSum(str);  //generate error when uncomment this, becoz this is not valid


     // Task d Method calling
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n-- Task d");
        Console.ResetColor();
        StudentBase();
    }






    // _______________________Methods Implementation COde

    // ************************  Optional Arguements **********************

    // Task a Method Implemenation
    public static void Greet(string greeting = "Hello", string name = "World")
    {
        Console.WriteLine($"{greeting}, {name}");
    }

    // Task b Method Implemenation

    public static double CalculateArea(double length = 1.0, double width = 1.0)
    {
        return length * width;
    }

    // Task c Method Implemenation
    public static int AddNumbers(int num1, int num2) { return num1 + num2; }
    public static int AddNumbers(int num1, int num2, int optional = 0) { return num1 + num2 + optional; }

    // Task d Method Implemenation
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Book(string title, string author = "Unknown") {

            Title = title;
            Author = author;
        }
    }

    // Methods Implementation
    // **************************  Generics ***************************

    // Task a Method Implemenation
    class MyList<T>
    {
        public List<T> List  = new();

        public void AddItem(T item) {

            List.Add(item);
        }

        public bool RemoveItem(T item) {
        
            return List.Remove(item);
        }

        public void DisplayList() { 
        
            foreach (T item in List)
            {
                Console.Write(item + ":");
            }
        }
    }

    // Task b Method Implemenation
    public static void Swap<T>(ref T first, ref T second)
    {
        T temp = first;
        first = second;
        second = temp;
    }

    // Task c Method Implemenation
    public static void ComputeSum<T>(T[] array) where T : struct, IComparable, IConvertible, IEquatable<T>, IComparable<T> 
    {
        if(array == null || array.Length == 0)
        {
            throw new ArgumentException("Array is null or empty.");
        }
        T sum = default(T); // initialize the sum with deafult value according to T

        foreach (T element in array )
        {
            sum = (T)((dynamic)sum + (dynamic)element);
        }

        Console.Write($"Array type: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{typeof(T)}");
        Console.ResetColor();
        Console.Write($"\tSum: {sum}\n");
    }


    // Task d Method Implemenation
    public static void StudentBase()
    {
        // Creat Dictionary
        // Add Records to dictionary
        Dictionary<int, string> StudentDict = new()
        {
                { 101, "Alice" },
                { 102, "Bob" },
                { 103, "Charlie" },
                { 104, "David" }
        };

        int studentId = 0;
        string? studentName;
        do
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("-- Student Database Menu");
            Console.ResetColor();
            
            Console.WriteLine("  1. View the student database");
            Console.WriteLine("  2. Search for a student by ID");
            Console.WriteLine("  3. Update a student's name");
            Console.WriteLine("  4. Exit the program");
            int option = 0;
            string? strOption;
            
            try
            {
                strOption = Console.ReadLine();
                if(string.IsNullOrEmpty(strOption))
                {
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.WriteLine("choose a valid option\n");
                    Console.ResetColor();
                    continue;
                }
                option = int.Parse(strOption);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("choose a valid option\n");
                Console.ResetColor();
                continue;
            }
            
            switch (option)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n<> Displaying Records\n");
                    Console.ResetColor();

                    foreach (KeyValuePair<int, string> myDict in StudentDict)
                    {
                        Console.WriteLine($"\tStudent ID : {myDict.Key}, Name : {myDict.Value}");
                    }
                    Console.WriteLine("\n");
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n<> Search For a Student by ID");
                    Console.ResetColor();

                    do
                    {
                        Console.WriteLine("  Enter ID to Search a Student: ");
                        string? strStdId;

                        try
                        {
                            strStdId = Console.ReadLine();

                            if (string.IsNullOrEmpty(strStdId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("please enter valid ID");
                                Console.ResetColor();
                                continue;
                            }
                            else studentId = int.Parse(strStdId);

                            if (!StudentDict.ContainsKey(studentId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Student Not Found!!");
                                Console.ResetColor();
                                continue;
                            }
                            else
                            {
                                studentName = StudentDict[studentId];
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Student with ID {studentId} : {studentName}");
                                Console.ResetColor();
                            }
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("please enter valid ID");
                            Console.ResetColor();
                            continue;
                        }
                    }
                    while (!StudentDict.ContainsKey(studentId));

                    Console.Write("\n");
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkGray; ;
                    Console.WriteLine("\n<> Update a Student's name");
                    Console.ResetColor();

                    string? strStdName;
                    do
                    {
                        try
                        {
                            Console.WriteLine("  Enter ID to update student's name: ");
                            strStdName = Console.ReadLine();
                            if (string.IsNullOrEmpty(strStdName))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("please enter valid ID");
                                Console.ResetColor();
                                continue;
                            }
                            else studentId = int.Parse(strStdName);

                            if (!StudentDict.ContainsKey(studentId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Student Not Found!!");
                                Console.ResetColor();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"Student with ID {studentId} : {StudentDict[studentId]}");
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("  Enter updated name: ");
                                        studentName = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(studentName))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("please enter name");
                                            Console.ResetColor();
                                            continue;
                                        }
                                        else
                                        {
                                            StudentDict[studentId] = studentName;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Updating name . . .");
                                            Console.ResetColor();
                                            break;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("please enter name");
                                        Console.ResetColor();
                                        continue;
                                    }
                                } while (true);
                            }
                        }
                        catch(FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("please enter valid ID");
                            Console.ResetColor();
                            
                        }
                    }
                    while (!StudentDict.ContainsKey(studentId));

                    Console.Write('\n');
                    break;

                case 4:
                    Console.ForegroundColor= ConsoleColor.DarkGray;
                    Console.WriteLine("Exiting From Program. . .");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("choose a valid option\n");
                    Console.ResetColor();
                    break;                  
            }
        } while (true);
    }    
}
