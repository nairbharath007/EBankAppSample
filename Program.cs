using EBankAppSample.Data;
using EBankAppSample.Repository;
using EBankAppSample.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace EBankAppSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("connString"));
            });


            builder.Services.AddControllers();

            //To avoid JSON cycles  1--2--3--1
            builder.Services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost4201", builder =>
                {
                    builder.WithOrigins("http://localhost:4201").AllowAnyHeader().AllowAnyMethod();
                });
            });


            builder.Services.AddTransient(typeof(IRepository<>), typeof(EntityRepository<>));
            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IDocumentService, DocumentService>();
            builder.Services.AddTransient<IQueryService, QueryService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
    }
}