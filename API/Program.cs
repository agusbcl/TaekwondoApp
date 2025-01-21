using TaekwondoApp;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

await app.InitializeDatabase();

app.MapGet("/", () => "TaekwondoApp");

app.Run();