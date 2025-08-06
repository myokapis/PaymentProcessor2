namespace TsysService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<TsysWorker>();

            // TODO: take this from the configuration
            builder.Services.Configure<HostOptions>(o => o.ShutdownTimeout = TimeSpan.FromSeconds(60));

            var host = builder.Build();
            host.Run();
        }
    }
}