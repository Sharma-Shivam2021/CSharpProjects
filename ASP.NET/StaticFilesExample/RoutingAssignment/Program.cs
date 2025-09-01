var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Dictionary<int, string> countries = new()
{
    { 1, "United States" },
    { 2, "Canada" },
    { 3, "United Kingdom" },
    { 4, "India" },
    { 5, "Japan" }
};

/* My Solution
//// GET: /countries -> return all
//app.Map("/countries", async context =>
//{
//    context.Response.ContentType = "text/plain";
//    context.Response.StatusCode = 200;

//    foreach (var country in countries)
//    {
//        await context.Response.WriteAsync($"{country.Key}, {country.Value}\n");
//    }
//});

//// GET: /countries/{countryID} where 1 <= id <= 100
//app.Map("/countries/{countryID:int:range(1,100)}", async context =>
//{
//    int id = Convert.ToInt32(context.Request.RouteValues["countryID"]);

//    context.Response.ContentType = "text/plain";

//    if (countries.ContainsKey(id))
//    {
//        context.Response.StatusCode = 200;
//        await context.Response.WriteAsync($"{countries[id]}");
//    }
//    else
//    {
//        context.Response.StatusCode = 404;
//        await context.Response.WriteAsync("[No Country]");
//    }
//});

//// GET: /countries/{countryID} where id >= 101
//app.Map("/countries/{countryID:int:min(101)}", async context =>
//{
//    context.Response.ContentType = "text/plain";
//    context.Response.StatusCode = 400;
//    await context.Response.WriteAsync("The CountryID should be between 1 and 100");
//});
*/

/* Instructor Solution */

#pragma warning disable ASP0014 // Suggest using top level route registrations

app.UseRouting();

app.UseEndpoints(
    endpoints =>
    {
        // Route 1: Get all countries
        endpoints.MapGet("/countries", async context =>
        {
            foreach (KeyValuePair<int, string> country in countries)
            {
                await context.Response.WriteAsync($"{country.Key}, {country.Value}");
            }
        });

        //Route 2: Get country by /id
        endpoints.MapGet("/countries/{countryID:int:range(1,100)}", async context =>
        {
            int countryId = Convert.ToInt32(context.Request.RouteValues["countryID"]);
            if (countries.ContainsKey(countryId))
            {
                string countryName = countries[countryId];
                await context.Response.WriteAsync($"{countryName}");
            }
            else
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("[No Country]");
            }
        });

        // Route 3: id>=101
        endpoints.MapGet("/countries/{countryID:int:min(101)}", async context =>
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("The CountryID should be between 1 and 100");
        });
    });
#pragma warning restore ASP0014 // Suggest using top level route registrations


app.Run(async context => {
    await context.Response.WriteAsync("No Response");
});

app.Run();
