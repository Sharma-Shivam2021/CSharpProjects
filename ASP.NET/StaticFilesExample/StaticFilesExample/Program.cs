using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions()
    {
        WebRootPath = "myroot"
    });


var app = builder.Build();

// to create a method such that only your created file can 
// be accessed use the following code
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new CompositeFileProvider(
//            new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "myroot")),
//            new NotFoundFileProvider())
//});



app.UseStaticFiles();// works with web root path (here: myroot)

app.UseStaticFiles(
    new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "mywebroot")
            )
    }
    );

app.MapGet("/", () => "Hello World!");

app.Run();
