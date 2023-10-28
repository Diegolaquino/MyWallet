using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.IoC.Config;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Repositories.Repositories;
using MyWallet.Services;
using MyWallet.Services.Contracts;
using MyWallet.Services.Services;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext")));
    //options.UseInMemoryDatabase("diegoteste"));

    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
    builder.Services.AddScoped<IExpenseService, ExpenseService>();
    builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
    builder.Services.AddScoped<IIncomeService, IncomeService>();
    builder.Services.AddScoped<IWalletRepository, WalletRepository>();
    builder.Services.AddScoped<IWalletService, WalletService>();
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

    app.MapControllers();

    app.Run();
}
catch (Exception)
{
    Console.WriteLine("An error occurred when starting the application");
	throw;
}
