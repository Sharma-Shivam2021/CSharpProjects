
namespace LinqExample
{
    internal class University
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"University {Name} with Id {Id}");
        }
    }
}
