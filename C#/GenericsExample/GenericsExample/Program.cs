
using GenericsExample;
using GenericsExample.GenericQuiz;


//Box<int,string> box = new Box<int,string>(1,"Hello");
//box.Display();

//Repository<Product> repository=new Repository<Product>();
//var product=new Product();
//repository.Add(product);

//var productOne = new Product();
//var productTwo=new Product();

//Console.WriteLine(Comparer.AreEqual(productOne, productOne));

//class Product
//{

//}

//Type type=typeof(ConfigurationManager<>);



//class ConfigurationManager<T>
//{
//    public T LoadedConfiguration { get; private set; }
//    public ConfigurationManager(T config)
//    {
//        LoadedConfiguration = config;
//    }

//    public static void SaveConfig(T config)
//    {

//    }
//}


/* -----------------------------
 * Actions do not return a value
 * Func results a value
 * -----------------------------
 */

//Action action = () => { Console.WriteLine("Hello World"); };
//action();

//Action<int> numPrint = (x) =>
//{
//    Console.WriteLine(x);
//};
//numPrint(10);

//Action<float, float> sum = (x, y) =>
//{
//    Console.WriteLine(x + y);
//};
//sum(1,2);

//Func<string> getName = () =>
//{
//    return "Shivam";
//};

//var myName=getName();
//Console.WriteLine(myName);

//Func<int, int, int> Sum = (x, y) =>
//{
//    return x + y;
//};

//Console.WriteLine(Sum(1,20));

//Predicate<int> isEven = (x) => x % 2 == 0;

//Console.WriteLine(isEven(24));



internal class Program
{
    private static void Main(string[] args)
    {
        EmailTask emailTask = new EmailTask()
        {
            Recipient = "abc@example.com",
            Message = "This is a Email Task that implements ITask"
        };

        ReportTask reportTask = new ReportTask()
        {
            ReportName = "Success"
        };


        TaskProcessor<EmailTask, string> emailTaskProcessor = new(emailTask);

        TaskProcessor<ReportTask, string> reportTaskProcessor = new(reportTask);

        Console.WriteLine(emailTaskProcessor.Execute());
        Console.WriteLine(reportTaskProcessor.Execute());
    }
}