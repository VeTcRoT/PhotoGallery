using PhotoGallery.MVC;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

await app.RunAsync();
