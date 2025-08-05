
// for Loop
/*
string rocket = "        |\r\n       / \\\r\n      / _ \\\r\n     |.o '.|\r\n     |'._.'|\r\n     |     |\r\n   ,'|  |  |`.\r\n  /  |  |  |  \\\r\n  |,-'--|--'-.|";

for (int i = 10; i >= 0; i--)
{   

    Console.Clear();
    Console.WriteLine(rocket);
    Console.WriteLine("Counter: "+i+ "\n__________________________");
    rocket =rocket+"\n";
    Thread.Sleep(500);
}
//Console.Clear();
//rocket = rocket+"\n__________________________";
//Console.WriteLine(rocket);
//Console.WriteLine("Rocket Landed Successfully");
*/

//while Loop
//int counter = 0;
//while (counter < 10)
//{
//    Console.WriteLine(counter);
//    counter++;
//}


//---------------------------------------

Console.WriteLine("Welcome to the Adventure Game!");
Console.WriteLine("Enter your character name: ");
string? playerName = Console.ReadLine();

int count = 0;
while (playerName == null && count < 3)
{
    Console.WriteLine("Please enter your name: ");
    playerName = Console.ReadLine();
    count++;
}

Console.WriteLine("Choose your character type ");
string playerCharacterType = Console.ReadLine()!;


Console.ReadKey();