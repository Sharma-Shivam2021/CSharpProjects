
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            LevelOne();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught in Main: " + ex.Message);
        }
    }

    static void LevelOne()
    {
        LevelTwo();
    }

    static void LevelTwo()
    {
        throw new Exception("Something went wrong!");
    }
}