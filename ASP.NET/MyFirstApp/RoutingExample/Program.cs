using RoutingExample.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
// Adding Custom Constraints to the builder
builder.Services.AddRouting(option =>
{
    option.ConstraintMap
    .Add("months", typeof(MonthsCustomConstraints));
});

var app = builder.Build();

app.MapGet("/test", () => "Hello World!");

// Routing is automatically enabled.
// No need for app.UseRouting() anymore.
// We use app.Map*() methods , * means it can be just Map or MapGet, or MapPost



app.Map("files/{filename}.{ext}", async (context) =>
{
    string? filename = context.Request.RouteValues["filename"]!.ToString();
    string? extension = context.Request.RouteValues["ext"]!.ToString();


    await context.Response.WriteAsync($"In Files: {filename}.{extension}");
});

/*
// Default empName is scott
// adding different constraints
//minlength(value) --> length of parameter
//maxlength(value)--> length of parameter
//length(value)
//min(value)___|_
//              _=> for int  value
// max(value)--|
// range(start,end)
// alpha --> only accepts alphabet
// regex(expression) --> regualar expression
*/
app.Map("employees/profile/{empName:length(4,7)=scott}", async (context) =>
{
    string? empName = context.Request.RouteValues["empName"]!.ToString();

    await context.Response.WriteAsync("Employee Name: " + empName);
});

// null value
// apply contraints on parameter like this {parameter:<datatype>?}
app.Map("products/details/{id:int?}", async (context) =>
{
    if (context.Request.RouteValues.ContainsKey("id"))
    {
        int id = int.Parse(context.Request.RouteValues["id"]!
            .ToString()!);
        await context.Response.WriteAsync($"Product details - product: {id}");
    }
    else
    {
        await context.Response.WriteAsync("Product details - id not supplied");
    }
});

// daily-diget report/{reportdate:datetime}
app.Map("daily-digest-report/{reportdate:datetime}", async (context) =>
{
    DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
    await context.Response.WriteAsync($"In daily-digest-report: {reportDate.ToShortDateString()}");
});

//cities /{ cityid: guid}
app.Map("cities/{cityid:guid}", async (context) =>
{
    Guid cityId = Guid.Parse(context.Request.RouteValues["cityid"]!.ToString()!);
    await context.Response.WriteAsync($"City ID: {cityId}");
});


// sales-report/2030/apr
app.Map("sales-report/{year:int:min(1900)}/{month:months}",
   async (context) =>
    {
        int year = int.Parse(context.Request.RouteValues["year"]!.ToString()!);
        string? month = context.Request.RouteValues["month"]!.ToString()!;
        await context.Response.WriteAsync($"Sales Report for fiscal {month}-{year}");
    });

// example showing precedence of routing in asp.net
// 1. "a/b/c/d" > "a/b/c"
// 2. "a/b" > "a/{parameter}"
// 3. "a/{b:int}" > "a/{b}"
// 4. "a/{b}" > "a/**" (catch all parameter) 

app.Map("sales-report/2024/jan", async (context) =>
{
    await context.Response.WriteAsync("Inside Sales Report 2024, jan");
});


// Fallback for any other requests
app.MapFallback(async (context) =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync($"No route matched at {context.Request.Path}");
});


app.Run();
