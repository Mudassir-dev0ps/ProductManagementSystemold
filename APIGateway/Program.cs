using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using MMLib.SwaggerForOcelot.DependencyInjection;
using MMLib.SwaggerForOcelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
//    .AddJsonFile("ocelot.Swagger.json", optional: false, reloadOnChange: true);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
    //.AddJsonFile("ocelot.Swagger.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

//await app.UseSwaggerForOcelotUI(opt =>
//{
//    opt.PathToSwaggerGenerator = "/swagger/docs";
//})
//.UseOcelot();
await app.UseOcelot();
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
