using MyFirstApp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

/*
// My Version of Calculator WebApi
//app.Run(async (HttpContext context) =>
//{
//    List<string> validOperations = new() { "add", "minus", "divide", "multiply", "remainder" };
//    var query = context.Request.Query;

//    if (!query.ContainsKey("firstNumber"))
//    {
//        context.Response.StatusCode = 400;
//        await context.Response.WriteAsync("<p>Missing query parameter: firstNumber</p>");
//        return;
//    }
//    if (!query.ContainsKey("secondNumber"))
//    {
//        context.Response.StatusCode = 400;
//        await context.Response.WriteAsync("<p>Missing query parameter: secondNumber</p>");
//        return;
//    }
//    if (!query.ContainsKey("operation"))
//    {
//        context.Response.StatusCode = 400;
//        await context.Response.WriteAsync("<p>Missing query parameter: operation</p>");
//        return;
//    }

//    string? operation = query["operation"];

//    if (!validOperations.Contains(operation!))
//    {
//        context.Response.StatusCode = 400;
//        await context.Response.WriteAsync("<p>Invalid input for 'operation'.</p>");
//        return;
//    }

//    if (double.TryParse(query["firstNumber"], out double firstNumber) &&
//        double.TryParse(query["secondNumber"], out double secondNumber))
//    {
//        double result = operation switch
//        {
//            "add" => firstNumber + secondNumber,
//            "minus" => firstNumber - secondNumber,
//            "multiply" => firstNumber * secondNumber,
//            "divide" => secondNumber != 0 ? firstNumber / secondNumber : double.NaN,
//            "remainder" => secondNumber != 0 ? firstNumber % secondNumber : double.NaN,
//            _ => double.NaN
//        };

//        context.Response.StatusCode = 200;
//        await context.Response.WriteAsync($"<p>Result: {result}</p>");
//        return;
//    }
//    else
//    {
//        context.Response.StatusCode = 400;
//        await context.Response.WriteAsync("<p>Invalid numbers provided.</p>");
//        return;
//    }
//});


//Instructor version
//app.Run(async (HttpContext context) =>
//{

//    if (context.Request.Method == "GET" && context.Request.Path == "/")
//    {
//        int firstNumber = 0, secondNumber = 0;
//        string? operation = null;
//        long? result = null;

//        if (context.Request.Query.ContainsKey("firstNumber"))
//        {
//            string firstNumberString = context.Request.Query["firstNumber"][0]!;
//            if (!string.IsNullOrEmpty(firstNumberString))
//            {
//                firstNumber = int.Parse(firstNumberString);
//            }
//            else
//            {
//                context.Response.StatusCode = 400;
//                await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
//            }
//        }
//        else
//        {
//            if (context.Response.StatusCode == 200)
//            {
//                context.Response.StatusCode = 400;
//            }
//            await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
//        }
//        if (context.Request.Query.ContainsKey("secondNumber"))
//        {
//            string secondNumberString = context.Request.Query["secondNumber"][0]!;
//            if (!string.IsNullOrEmpty(secondNumberString))
//            {
//                secondNumber = Convert.ToInt32(context.Request.Query["secondNumber"][0]);
//            }
//            else
//            {
//                if (context.Response.StatusCode == 200)
//                    context.Response.StatusCode = 400;
//                await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
//            }
//        }
//        else
//        {
//            if (context.Response.StatusCode == 200)
//                context.Response.StatusCode = 400;
//            await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
//        }
//        if (context.Request.Query.ContainsKey("operation"))
//        {
//            operation = Convert.ToString(context.Request.Query["operation"][0]);
//            result = (operation) switch
//            {
//                "add" => firstNumber + secondNumber,
//                "subtract" => firstNumber - secondNumber,
//                "multiply" => firstNumber * secondNumber,
//                "divide" => (secondNumber != 0) ? firstNumber / secondNumber : 0,
//                "mod" => (secondNumber != 0) ? firstNumber % secondNumber : 0,
//                _ => throw new NotImplementedException(),
//            };

//            if (result.HasValue)
//            {
//                await context.Response.WriteAsync(result.Value.ToString());
//            }
//            else
//            {
//                if (context.Response.StatusCode == 200)
//                    context.Response.StatusCode = 400;
//                await context.Response.WriteAsync("Invalid input for 'operation'\n");
//            }
//        }
//        else
//        {
//            if (context.Response.StatusCode == 200)
//                context.Response.StatusCode = 400;
//            await context.Response.WriteAsync("Invalid input for 'operation'\n");
//        }
//    }
//});
*/


// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("From Middleware 1\n");
    // Calling the next middleware using chaining method.
    await next(context);
});

//middleware 2
//app.UseMiddleware<MyCustomMiddleware>();
// Using Extension
app.UseMyCustomMiddleware();

// Using Custom Middleware Class Convention
app.UseHelloCustomMiddleware();

//middleware 3 - Short circuiting middleware after this no middleware will be called
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("From Middleware 3\n");
});

app.Run();


/*
 * Recommended order of execution of Middlewares
 * 
 * Exception Handlers
 * HSTS ->  Http Strict Transport Security
 * HttpsRedirection
 * Static Files
 * Routing
 * CORS
 * Authentication
 * Authorization
 * Custom Middlewares
 * Endpoint
 * 
 */