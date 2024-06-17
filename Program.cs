using Final_Project.data;

namespace Final_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddCors(s => s.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin()
                                                     .AllowAnyMethod()
                                                     .AllowAnyHeader()));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton(typeof(dataContext), typeof(Database));
            builder.Services.AddMvc();


            var app = builder.Build();
            app.UseCors("MyPolicy");
            

            app.UseHttpsRedirection();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.MapControllers();


            app.MapControllers();

            app.Run();
        }
    }
}