using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using WebAPI;

var app = Startup.InitializeApp(args);
var builder = WebApplication.CreateBuilder(args);
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
app.Run();
