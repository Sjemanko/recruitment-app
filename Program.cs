using Microsoft.EntityFrameworkCore;
using recruitment_app.Data;
using recruitment_app.Repositories;
using recruitment_app.Repositories.LanguageRepository;
using recruitment_app.Repositories.QuestionRepository;
using recruitment_app.Services;
using recruitment_app.Services.LanguageServices;
using recruitment_app.Services.QuestionServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

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
