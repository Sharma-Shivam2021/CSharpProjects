using System.Text.RegularExpressions;

namespace RegExExample;

internal class Program
{
    static void Main(string[] args)
    {
        string pattern = @"(\w+)@(\w+).(\w+)";
        Regex regex = new Regex(pattern);

        string text = "123456 aaa@gmail.com adasdadgak";

        MatchCollection matches = regex.Matches(text);
        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }

    }
}
