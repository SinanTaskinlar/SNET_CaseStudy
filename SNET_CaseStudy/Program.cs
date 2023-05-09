
using SNET_CaseStudy.Business;
using SNET_CaseStudy.DataAccess;
using SNET_CaseStudy.DataAccess.EntityFramework;
using SNET_CaseStudy.DataAccess.InMemoryDatabase;
using SNET_CaseStudy.Middlewares;
using SNET_CaseStudy.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//----

builder.Services.AddLogging( z =>
{
    z.AddConsole();
    z.AddDebug();
});

builder.Services.AddHostedService<QueueService>();

builder.Services.AddCors(p => p.AddPolicy("SNET_app", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddSingleton<ICustomerDal, InMemoryCustomerDal>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
//-----


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("SNET_app");


app.UseAuthorization();
app.MapControllers();
app.UseLoggingMiddleware();
app.Run();