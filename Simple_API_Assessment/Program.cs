using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Data;

namespace Simple_API_Assessment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<DataContext>(options =>
                        options.UseNpgsql(hostContext.Configuration.GetConnectionString("DataContext")));
                    services.AddControllers();
                });
    }
}
