
using Menu.Data;
using Menu.Logic.Dto;
using Menu.Logic.Logic;
using Menu.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Menu.Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option => option.SwaggerDoc("v1",new OpenApiInfo { Title = "Meal API", Version = "v1"}));

            builder.Services.AddTransient(typeof(Repository<>));
            builder.Services.AddTransient<MealLogic>();
            builder.Services.AddTransient<IngredientLogic>();
            builder.Services.AddTransient<IngredientsAmountLogic>();
            builder.Services.AddTransient<DtoProvider>();

            builder.Services.AddDbContext<MenuContext>(opt =>
            {
                //macen: Sqlite (nuget csomag is kell hozzá)
                opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MovieClubDbX;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
                .UseLazyLoadingProxies();
            });
            builder.Services.AddSignalR();

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
