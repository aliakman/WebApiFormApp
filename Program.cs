using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiFormApp.Services;
using WebApiFormApp.Statics;

namespace WebApiFormApp;

static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((services) => {
                
                services.AddSingleton<Info>();

                services.AddHttpClient("api", c =>
                {
                    c.BaseAddress = new Uri("http://localhost:5183/api/");
                });

                services.AddTransient<UserSettingsForm>();
                services.AddTransient<LoginRegisterForm>();

                services.AddTransient<AuthService>();
                services.AddTransient<UserService>();
                services.AddTransient<RoleService>();

            }).Build();

        ServiceProvider = host.Services;
        bool run = true;

        while (run)
        {
            using var login = ServiceProvider.GetRequiredService<LoginRegisterForm>();
            if (login.ShowDialog() != DialogResult.OK) break;

            using var userSettings = ServiceProvider.GetRequiredService<UserSettingsForm>();
            Application.Run(userSettings);
            run = userSettings.WantToLogout;
        }
    }
}