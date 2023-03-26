using System;
using System.Net.WebSockets;

while (true)
{
    // Сreate an array and fill it with random numbers from 1 to 26
    Console.Clear();
    var arrayLength = InputArraylength();

    if (arrayLength <= 0)
    {
        continue;
    }

    var array = ArrayCreator(arrayLength);
    Console.WriteLine("\nArray of integers:");
    PrintIntArray(array);

    // Сreate two character arrays, the first one is filled with symbols with paired numbers from integer array, and the second one with unpaired
    var evenCharArray = NubrersToChars(array, true);
    var oddCharArray = NubrersToChars(array, false);

    // Сhange the letters a, e, i, d, h, j to uppercase and the rest to lowercase
    evenCharArray = ConvertCharCase(evenCharArray);
    oddCharArray = ConvertCharCase(oddCharArray);

    // Сompare two arrays where there are more capital letters
    int comparerArraysOfUppercase = ComparerArraysOfUppercase(evenCharArray, oddCharArray);

    if (comparerArraysOfUppercase > 0)
    {
        Console.WriteLine("\nEven char array contains more capital letters");
    }
    else if (comparerArraysOfUppercase < 0)
    {
        Console.WriteLine("\nOdd char array contains more capital letters");
    }
    else
    {
        Console.WriteLine("\nBoth arrays contain the same number of capital letters");
    }

    // Print both char arrays
    if (evenCharArray.Length > 0)
    {
        Console.WriteLine("\nEven char array:");
        PrintCharArray(evenCharArray);
    }
    else
    {
        Console.WriteLine("\nEven char array:");
        Console.WriteLine("\nEven array contains no elements");
    }

    if (oddCharArray.Length > 0)
    {
        Console.WriteLine("\nOdd char array:");
        PrintCharArray(oddCharArray);
    }
    else
    {
        Console.WriteLine("\nOdd char array:");
        Console.WriteLine("\nOdd array contains no elements");
    }

    // Make a request to repeat the program
    Console.Write("\nIf you want to repeat enter 'Y'");
    var repeatIndicator = Console.ReadKey().KeyChar;

    if (repeatIndicator != 'Y' && repeatIndicator != 'y' && repeatIndicator != 'Н' && repeatIndicator != 'н')
    {
        break;
    }
}

int InputArraylength()
{
    int result;
    Console.Write("Please enter the length of the array: ");
    var isConversSuccess = int.TryParse(Console.ReadLine(), out result);

    if (!isConversSuccess || result <= 0)
    {
        Console.WriteLine("\nYou need to enter an integer greater than zero!\nPlease try again");
        Console.ReadKey();
    }

    return result;
}

int[] ArrayCreator(int arrayLenght)
{
    var array = new int[arrayLenght];
    var random = new Random();

    for (int i = 0; i < array.Length; i++)
    {
        array[i] = random.Next(1, 27);
    }

    return array;
}

char[] NubrersToChars(int[] array, bool useEvenNumbers)
{
    var counter = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if ((array[i] % 2 == 0) == useEvenNumbers)
        {
            counter++;
        }
    }

    var newArray = new char[counter];
    counter = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if ((array[i] % 2 == 0) == useEvenNumbers)
        {
            newArray[counter] = (char)(array[i] + 64);
            counter++;
        }
    }

    return newArray;
}

char[] ConvertCharCase(char[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        switch (array[i])
        {
            case 'A':
            case 'E':
            case 'I':
            case 'D':
            case 'H':
            case 'J':
                array[i] = char.ToUpper(array[i]);
                break;
            default:
                array[i] = char.ToLower(array[i]);
                break;
        }
    }

    return array;
}

int ComparerArraysOfUppercase(char[] firstArray, char[] secondArray)
{
    int counter = 0;

    foreach (var letter in firstArray)
    {
        if (char.IsUpper(letter))
        {
            counter++;
        }
    }

    foreach (var letter in secondArray)
    {
        if (char.IsUpper(letter))
        {
            counter--;
        }
    }

    return counter;
}

void PrintIntArray(int[] array)
{
    Console.WriteLine();

    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }

    Console.WriteLine();
}

void PrintCharArray(char[] array)
{
    Console.WriteLine();

    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }

    Console.WriteLine();
}