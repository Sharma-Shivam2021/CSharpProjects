
//int num = 10;
//double price = 16.36;
//string name = "Frank";

//// Interpolation
//Console.WriteLine($"The number is {num}");

//// Concatenation       
//Console.WriteLine("The number is " + num);
/*
//// String formatting
//Console.WriteLine("The number is {0}", num);

//// String formatting with multiple variables
//Console.WriteLine("{0} bid for the lot number {1} and the price is {2}.",name,num,price);
*/

/*
// Get first number
double number1 = 0.0;
Console.WriteLine("Enter first number ");
number1 = double.Parse(Console.ReadLine()!);

// Get second number
double number2 = 0.0;
Console.WriteLine("Enter second number ");
number2 = double.Parse(Console.ReadLine()!);

// Sum of the numbers
double sum = number1 + number2;
Console.WriteLine($"The sum of {number1} and {number2} is {sum}");

*/


// Random Number Game
/*

Random random = new Random();

int randomNumber = random.Next(1, 11);

Console.WriteLine("Guess the number");

string? userGuess = Console.ReadLine();

int num1 = 0;

bool isNumber = int.TryParse(userGuess, out num1);

if (isNumber)
{
    if (num1 == randomNumber)
    {
        Console.WriteLine("Guessed Correctly");
    }
    else
    {
        Console.WriteLine("Wrong Guess! The number was " + randomNumber);
    }
}
*/


// ref modifier
void ModifyValue(ref int number)
{
    number += 10;
}

int myNumber = 5;
ModifyValue(ref myNumber);
Console.WriteLine(myNumber);

// out modifier

void GetValues(out int result)
{
    result = 42;
}

int myValue;
GetValues(out myValue);
Console.WriteLine(myValue);

// returning multiple values
void Calculate(int x, int y, out int sum, out int product)
{
    sum = x + y;
    product = x * y;
}

int a=5,b=3,sum,product;
Calculate(a,b,out sum,out product);
Console.WriteLine($"Sum: {sum}, Product: {product}");

// in modifier

void PrintValue(in int number)
{
    Console.WriteLine(number);
}

int myNumber2 = 100;
PrintValue(myNumber2);