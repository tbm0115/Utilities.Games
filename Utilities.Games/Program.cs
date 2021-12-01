using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using LOTR_RiseToWar = Utilities.Games.Pages.Subsites.LOTR_RiseToWar;

namespace Utilities.Games
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<Utilities.Games.Models.Notifications.NotificationTriggers>();
            builder.Services.AddScoped<LOTR_RiseToWar.Models.LocalStores.ServerStore>();
            builder.Services.AddScoped<LOTR_RiseToWar.Models.LocalStores.CommanderStore>();

            var host = builder.Build();

            await host.RunAsync();
        }
    }
}