


internal class Program
{
    private static void Main(string[] args)
    {

        DriverFunction();

    }

    // Driver function

    public static void DriverFunction()
    {
        do
        {
            Console.WriteLine("\n\nSelect an Option\n");
            Console.WriteLine("1. StringConcatenation");
            Console.WriteLine("2. SubstringFetching");
            Console.WriteLine("3. StringInterpolation");
            Console.WriteLine("4. ArrayDeclareInitialize");
            Console.WriteLine("5. ArrayIteration");
            Console.WriteLine("6. SumOfArrayElements");
            Console.WriteLine("7. FindMaximum");
            Console.WriteLine("8. ArrayReversal");
            Console.WriteLine("9. Boxing");
            Console.WriteLine("10.UnBoxing");
            Console.WriteLine("11.DynamicVariable");
            Console.WriteLine("12.Exit");

            string userInputStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInputStr))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                continue;
            }

            if (int.TryParse(userInputStr, out int userInput))
            {
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("You selected StringConcatenation\n");                       
                        StringConcatenation();
                        break;
                    case 2:
                        Console.WriteLine("You selected SubstringFetching\n");                       
                        Console.WriteLine("Enter string : ");
                        string str = Console.ReadLine();
                        Substringfetching(str);
                        break;
                    case 3:
                        Console.WriteLine("You selected StringInterpolation\n");
                        StringInterpolation();
                        break;
                    case 4:
                        Console.WriteLine("You selected ArrayDeclareInitialize\n");

                        ArrayDeclareInitialize();
                        break;
                    case 5:
                        Console.WriteLine("You selected ArrayIteration\n");
                        ArrayIteration();
                        break;
                    case 6:
                        Console.WriteLine("You selected SumOfArrayElements\n");
                        SumOfArrayElements();
                        break;
                    case 7:
                        Console.WriteLine("You selected FindMaximum\n");
                        FindMaximum();
                        break;
                    case 8:
                        Console.WriteLine("You selected ArrayReversal\n\n");
                        Console.Write("Enter length of array : ");
                        int len = int.Parse(Console.ReadLine());

                        int[] arr = new int[len];
                        Console.WriteLine($"\nEnter {len} elements");
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = int.Parse(Console.ReadLine());
                        }
                        ArrayReversal(arr);
                        break;
                    case 9:
                        Console.WriteLine("You selected Boxing\n");
                        Boxing();
                        break;
                    case 10:
                        Console.WriteLine("You Selected UnBoxing\n");
                        UnBoxing();
                        break;
                    case 11:
                        Console.WriteLine("You selected DynamicVariable\n");
                        DynamicVariable();
                        break;

                    case 12:

                        Console.WriteLine("Exiting from menu");
                        Environment.Exit(0);
                        break;
                        
                    default:
                        Console.WriteLine("Invalid input. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
            }
        } while (true);


    }

    // Task 01
    public static void StringConcatenation()
    {

        Console.WriteLine("_______________ Task 01 _______________");
        Console.Write("\nEnter First name: ");
        string? firstName = Console.ReadLine();

        Console.Write("Enter Last name: ");
        string? lastName = Console.ReadLine();

        Console.WriteLine("Hello " + firstName + " " + lastName);
    }



    // Task 02

    public static void Substringfetching(string str)
    {
        Console.WriteLine("_______________ Task 02 _______________");
        Console.Write("\nLast 5 characters : ");
        
        int len = str.Length;

        //Console.WriteLine(len);

        int index = len - 5; 
        while (index < len)
        {
            Console.Write(str[index]);
            index++;
        }
    }

    // Task 03

    public static void StringInterpolation()
    {
        Console.WriteLine("_______________ Task 03 _______________");

        Console.Write("\nCurrent Temprature : ");
        double? temprature = double .Parse(Console.ReadLine());

        Console.Write("Your City : ");
        string? city = Console.ReadLine();

        Console.WriteLine($"\nThe temperature in {city} is {temprature} degrees Celsius.");
    }

    // Task 04
    public static void ArrayDeclareInitialize()
    {
        Console.WriteLine("_______________ Task 04 _______________");
        int[] numbers = new int[5] { 1,2,3,4,5};
        Console.WriteLine("\n\nElements are: ");

        foreach(int num in numbers) { Console.WriteLine(num); }
    }

    // Task 05

    public static void ArrayIteration()
    {
        Console.WriteLine("_______________ Task 05 _______________");

        Console.WriteLine("\n\nIteration Of Array using For Loop\n");

        string[] fruits = { "bnana", "orange", "mango", "pineApple", "Apple" };

        for (int i = 0; i < fruits.Length; i++)
        {
            Console.WriteLine(fruits[i]);
        }

        Console.WriteLine("\nIteration Of Array using ForEach Loop\n");

        string[] colors = { "red", "blue", "orange", "black", "white" };

        foreach (var item in colors)
        {
            Console.Write(item + ", ");
        }
    }

    // Task 06

    public static void SumOfArrayElements()
    {
        Console.WriteLine("_______________ Task 06 _______________");


        int[] score = { 82, 85, 90, 50, 65, 45, 76, 55, 90, 78 };

        Console.Write("\n\nElements ");
        foreach (var item in score)
        {
            Console.Write(item + ":");
        }
        int index = 0;
        int sum = 0;
        do
        {
            sum += score[index];
            index++;

        } while (index < score.Length);
        Console.WriteLine($"\nSum of array elements: {sum}");
    }

    // Task 07
    public static void FindMaximum()
    {
        Console.WriteLine("_______________ Task 07 _______________");

        int[] values = { 10, 25, 7, 42, 18 };

        Console.Write("\n\nElements ");
        foreach (var item in values)
        {
            Console.Write(item + ":");
        }

        if (values.Length == 0)
        {
            throw new ArgumentException("The array cannot be empty.");
        }

        int max = values[0]; // Initialize max to the first element of the array
        int index = 1;

        while (index < values.Length)
        {
            if (values[index] > max)
            {
                max = values[index];
            }
            index++;
        }

        Console.WriteLine($"\n\nThe maximum value in the array is: {max}");
    }

    // Task 08

    public static void ArrayReversal(int[] numbers)
    {
        Console.WriteLine("_______________ Task 08 _______________");
        int len = numbers.Length;
        if (len == 0)
        {
            Console.WriteLine("Empty");
            return;
        }
        else
        {
            Console.Write("\n\nPrinting Original Array : ");
            foreach (var item in numbers) { Console.Write(item + ":"); }


            int length = numbers.Length;

            for (int i = 0; i < length / 2; i++)
            {
                // Swap elements at index i and length - i - 1
                int temp = numbers[i];
                numbers[i] = numbers[length - i - 1];
                numbers[length - i - 1] = temp;
            }

            Console.Write("\n\nPrinting Reverse Array: ");
            foreach(var item in numbers) { Console.Write(item + ":"); }
        }

    }

    // Task 09
    public static void Boxing()
    {
        Console.WriteLine("_______________ Task 09 _______________");
        Console.WriteLine("\n\nInt Boxing . . .\n");

        int x = 42;

        
        object boxedX = x;

        
        int y = (int)boxedX;

        
        Console.WriteLine("The value of 'y' is: " + y);

        Console.WriteLine("\n\nDouble Boxing . . .\n");

        double doubleValue = 3.14159; 

        
        object boxedValue = doubleValue;

        
        double unboxedValue = (double)boxedValue;

        
        Console.WriteLine("The value of 'unboxedValue' is: " + unboxedValue);
    }

    // Task 10
    public static void UnBoxing()
    {

        Console.WriteLine("_______________ Task 10 _______________");
        Console.WriteLine("\n\na) Boxing and Unboxing Of array elements. . . \n\n");

        int[] numbers = { 1, 2, 3, 4, 5, 6 };

        foreach (var item in numbers)
        {
            object boxedValue = item; // box the current value
            int newVar = (int)boxedValue; // unbox and store in new variable
            int sqauredValue = newVar * newVar; // squared the unboxValue

            Console.WriteLine($"Original Value : {item} ");
            Console.WriteLine($"Squared  Value : {sqauredValue}\n");
        }


        Console.WriteLine("b) Boxing and Unboxing Of Generic List elements. . . \n");

        List<object> mixedList = new List<object>();

        // Add elements of different value types
        mixedList.Add(42); // int
        mixedList.Add(3.14159); // double
        mixedList.Add('A'); // char

        // Display the elements and their types
        Console.WriteLine("Elements in the list and their types:_____\n");
        foreach (var item in mixedList)
        {
            Console.WriteLine($"Value: {item} | Type: {item.GetType()}");
        }

        // Retrieving and unboxing elements 
        int intValue = (int)mixedList[0];
        double doubleValue = (double)mixedList[1];
        char charValue = (char)mixedList[2];

        // Display the retrieved values and their types
        Console.WriteLine("\nRetrieved values and their types:_____\n");
        Console.WriteLine($"Int Value: {intValue} | Type: {intValue.GetType()}");
        Console.WriteLine($"Double Value: {doubleValue} |  Type: {doubleValue.GetType()}");
        Console.WriteLine($"Char Value: {charValue} | Type: {charValue.GetType()}");

    }

    // Task 11 
    public static void DynamicVariable()
    {
        Console.WriteLine("_______________ Task 11 _______________\n");
        Console.WriteLine("a)\n");
        dynamic myVariable; // decalre dyanamic variable

        myVariable = 42; // assign an integar value

        Console.WriteLine( $"Integar Value : {myVariable}"); // display

        myVariable = "Hello world!"; // assign string value 

        Console.WriteLine($"String value : {myVariable}"); // display again

        Console.WriteLine("\n\nb)\n");
        dynamic myVariable2;

        myVariable2 = 42; // assign an integar value

        Console.WriteLine($"Type Of myVariable2  : {myVariable2.GetType()}"); // display

        myVariable2 = 2.54;

        Console.WriteLine($"Type Of myVariable2  : {myVariable2.GetType()}"); // display

        myVariable2 = "Hello world!";

        Console.WriteLine($"Type Of myVariable2  : {myVariable2.GetType()}"); // display

        myVariable2 = DateTime.Now;

        Console.WriteLine($"Type Of myVariable2  : {myVariable2.GetType()}"); // display


    }

}