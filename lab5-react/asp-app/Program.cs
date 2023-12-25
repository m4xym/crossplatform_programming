using System.Net;
using Newtonsoft.Json;
using WebApplication1;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});


var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.Use((ctx, next) =>
{
    ctx.Response.Headers["Access-Control-Allow-Origin"] = "*";
    return next();
});


app.MapGet("/", () => "Hello World!");

app.MapPost("/lab1", async (HttpContext context) =>
{
    using (var reader = new StreamReader(context.Request.Body))
    {
        var requestBody = await reader.ReadToEndAsync();
        var requestObject = JsonConvert.DeserializeObject<RequestObject>(requestBody);
        var lab1Result = Labs.Lab1(requestObject.Text);
        await context.Response.WriteAsync(lab1Result);
    }
});

app.MapPost("/lab2", async (HttpContext context) =>
{
    using (var reader = new StreamReader(context.Request.Body))
    {
        var requestBody = await reader.ReadToEndAsync();
        var requestObject = JsonConvert.DeserializeObject<RequestObject>(requestBody);
        var lab1Result = Labs.Lab2(requestObject.Text);
        await context.Response.WriteAsync(lab1Result);
    }
});

app.MapPost("/lab3", async (HttpContext context) =>
{
    using (var reader = new StreamReader(context.Request.Body))
    {
        var requestBody = await reader.ReadToEndAsync();
        var requestObject = JsonConvert.DeserializeObject<RequestObject>(requestBody);
        var lab1Result = Labs.Lab3(requestObject.Text);
        await context.Response.WriteAsync(lab1Result);
    }
});

app.Run();

class RequestObject
{
    public string Text { get; set; }
}
