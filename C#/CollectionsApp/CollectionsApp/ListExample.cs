namespace CollectionsApp;

internal class ListExample
{
    public ListExample()
    {
        List<int> numbers = new List<int> { 10, 15, 3, 9 };
        numbers.Sort();

        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();

        // using predicate keyword
        Predicate<int> isLesserThanOrEqualToTen = (x => x <= 10);
        List<int> findMethod = numbers.FindAll(isLesserThanOrEqualToTen);

        //using lambda 
        List<int> findMethodLambda = numbers.FindAll(x => x <= 10);

        foreach (int i in findMethod)
        {
            Console.WriteLine(i);
        }

        // Any method:
        // Determines whether ANY element of a sequence exists or
        // satisfies a condition
        // Return bool output
        bool greaterThanFive= numbers.Any(z=>z>5);

        List<Product> products = new List<Product>();

        products.Add(new Product { Name = "Berries", Price = 2.6 });
        products.Add(new Product { Name = "Apple", Price = 9.99 });
        products.Add(new Product { Name = "Shake", Price = 5.49 });

        //foreach (Product product in products)
        //{
        //    Console.WriteLine(product.Name);
        //    Console.WriteLine(product.Price);
        //    Console.WriteLine();
        //}


        List<Product> cheapProduct = products.Where(p => p.Price < 4.0).ToList();
        foreach (Product product in cheapProduct)
        {
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}

//A delegate in C# is a type that represents references to
//methods with a specific parameter list and return type.
//It allows methods to be passed as parameters, stored,
//and invoked dynamically.
//Delegates are similar to function pointers in C++,
//but are type-safe and secure.

