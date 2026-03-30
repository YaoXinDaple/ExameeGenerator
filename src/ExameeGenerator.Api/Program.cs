using ExameeGenerator.Api.Endpoints;
using ExameeGenerator.Api.ExceptionHandling;
using ExameeGenerator.Application;
using ExameeGenerator.Domain;
using ExameeGenerator.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Examee Generator API",
        Version = "v1"
    });
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDomain();
builder.Services.AddApplication();

var app = builder.Build();

// 启用全局异常处理中间件（要尽量靠前）
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examee Generator API v1");
        c.RoutePrefix = "swagger";
    });
}


app.MapExamEndpoints();

// 暴露健康检查端点
//app.MapHealthChecks("/health");

app.Run();


