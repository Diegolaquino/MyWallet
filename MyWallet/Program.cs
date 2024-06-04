using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyWallet.Data;
using MyWallet.IoC.Config;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Repositories.Repositories;
using MyWallet.Services;
using MyWallet.Services.Contracts;
using MyWallet.Services.Services;
using System.Text;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowOrigin", builder =>
        {
            builder.WithOrigins("https://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin();
        });
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    //options.UseInMemoryDatabase("diegoteste"));

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "AuthorityMyWalletAPI",
            ValidAudience = "sua_audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sua_chave_secreta"))
        };
    });

    builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
    builder.Services.AddScoped<IExerciseService, ExerciseService>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<IHealthRepository, HealthRepository>();
    builder.Services.AddScoped<IHealthService, HealthService>();
    builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
    builder.Services.AddScoped<IExpenseService, ExpenseService>();
    builder.Services.AddScoped<IWalletRepository, WalletRepository>();
    builder.Services.AddScoped<IWalletService, WalletService>();
    builder.Services.AddScoped<IReminderService, ReminderService>();
    builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
    builder.Services.AddScoped<IInvoiceService, InvoiceService>();
    builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
    builder.Services.AddScoped<IGoalService, GoalService>();
    builder.Services.AddScoped<IGoalRepository, GoalRepository>();
    builder.Services.AddScoped<IUoW, UoW>(); 


    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddSingleton(AutoMapperConfig.Configure());

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseCors("AllowOrigin");

    app.MapControllers();

    app.Run();
}
catch (Exception)
{
    Console.WriteLine("An error occurred when starting the application");
    throw;
}