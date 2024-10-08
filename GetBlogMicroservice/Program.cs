using GetBlogMicroservice.Clients;
using GetBlogMicroservice.Options;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting up Inventory Service.....");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(4, retryAttemp => TimeSpan.FromSeconds(Math.Pow(2,retryAttemp)/2));

builder.Services.AddHttpClient<IBlogClient, BlogClient>().ConfigureHttpClient(
    (serviceProvider, httpClient) =>
    {
        var httpClientOption = serviceProvider.GetRequiredService<BlogClientOption>();
        httpClient.BaseAddress=httpClientOption.BaseAddress;
        httpClient.Timeout = httpClientOption.TimeOut;
    }).AddPolicyHandler(retryPolicy);

builder.Services.AddOptions<BlogClientOption>()
    .BindConfiguration("BlogClient")
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddSingleton(
    resolver => resolver.GetRequiredService<IOptions<BlogClientOption>>()
        .Value);

builder.Services.AddSerilog();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
