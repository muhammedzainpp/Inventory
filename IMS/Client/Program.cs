using Blazored.Toast;
using IMS.Client;
using IMS.Client.Contracts.Inventories;
using IMS.Client.Contracts.Products;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using static System.Net.WebRequestMethods;

namespace IMS.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7029") });
            builder.Services.AddBlazoredToast();
            builder.Services.AddScoped<IInvetoryServices, InventoryServices>();
            builder.Services.AddScoped<IProductServices, ProductServices>();

            await builder.Build().RunAsync();
        }
    }
}