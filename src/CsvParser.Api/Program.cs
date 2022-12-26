using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using CsvParser.Persistence.Configuration;
using CsvParser.Core.Configuration;
using MediatR;
using CsvParser.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

CsvFormatConfiguration configuration = new CsvFormatConfiguration();
builder.Configuration.Bind("CsvFormat", configuration);
builder.Services.AddSingleton(configuration);

builder.Services.AddCoreServices();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("CsvParserDb"));

builder.Services.AddMediatR(configuration => 
{
    configuration.AsScoped();
}, Assembly.GetExecutingAssembly());


builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var path = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(path);

    options.CustomOperationIds(info =>
    {
        return info.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();
app.UseCleanDatabase();

app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.DisplayOperationId();
    c.DisplayRequestDuration();
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
