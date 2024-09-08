using CQRS;
using CQRS.Services.Blog.Commands;
using CQRS.Services.Blog.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add dependency injection
builder.Services.AddDbContext<AppDbContext>(opt =>
{
  opt.UseSqlServer(connectionString);
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddScoped<CreateBlog>();
builder.Services.AddScoped<UpdateBlog>();
builder.Services.AddScoped<DeleteBlog>();
builder.Services.AddScoped<GetBlog>();
builder.Services.AddScoped<GetBlogList>();

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
