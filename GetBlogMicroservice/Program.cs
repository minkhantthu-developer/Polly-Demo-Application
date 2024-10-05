using GetBlogMicroservice.Clients;
using GetBlogMicroservice.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IBlogClient, BlogClient>().ConfigureHttpClient(
    (serviceProvider, httpClient) =>
    {
        var httpClientOption = serviceProvider.GetRequiredService<BlogClientOption>();
        httpClient.BaseAddress=httpClientOption.BaseAddress;
        httpClient.Timeout = httpClientOption.TimeOut;
    });


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
