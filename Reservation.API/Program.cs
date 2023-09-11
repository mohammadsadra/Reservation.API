using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Reservation.API.DbContexts;
using Reservation.API.Repositories;
using Reservation.API.Services;
using Serilog;
internal class Program
{
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/logsinfo.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseSerilog();

        // Add services to the container.

        builder.Services.AddControllers(option =>
        {
            option.ReturnHttpNotAcceptable = true;
        })
            .AddNewtonsoftJson()
            .AddXmlDataContractSerializerFormatters();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

        #if DEBUG
        builder.Services.AddSingleton<IMailService, LocalMailService>();
#else
        builder.Services.AddSingleton<IMailService, CloudMailServixe>();
#endif

        builder.Services.AddDbContext<ReservationDbContext>(option =>
        {
            option.UseSqlite(builder.Configuration["ConnectionStrings:DevelopeConnectionString"]);
        });
        builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        // app.MapControllers();

        app.Run();
    }
}