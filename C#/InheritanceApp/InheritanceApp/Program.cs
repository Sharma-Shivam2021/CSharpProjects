namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee employee1 = new Employee("John Doe",25,"Ananlyst",101);
            //Employee employee2 = new Employee("John Who",27,"Sales Admin",102);
            //Console.WriteLine();
            //employee1.DisplayEmployeeInfo();
            //Console.WriteLine();
            //employee2.DisplayEmployeeInfo();

            Manager manager = new("Manager 1", 42, "Managaer", 10221,12);
            manager.DisplayManagerInfo();
            manager.BecomeOlder(10);
            Console.WriteLine();
            manager.DisplayManagerInfo();
        }
    }
}