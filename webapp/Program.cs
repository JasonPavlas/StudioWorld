using webapp.Data;
using webapp.Data.Repositories;
using webapp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => {
    // Apply anti-forgery token validation to all POST requests by default
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

// Configure logging for Azure App Service
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddAzureWebAppDiagnostics();

// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Add repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// Register application services
builder.Services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IBookingService, BookingService>();

// Add diagnostics for database errors
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add global exception handling
builder.Services.AddExceptionHandler<webapp.Middleware.GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Add caching support
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();

// Add health checks
builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>(name: "database_check")
    .AddCheck<webapp.HealthChecks.EnvironmentHealthCheck>("environment_check");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Add exception handling middleware
app.UseExceptionHandler();

// Enable response caching
app.UseResponseCaching();

// Map health checks endpoint
app.MapHealthChecks("/health");

app.UseHttpsRedirection();

// Use static files with caching
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Cache static files for 1 day
        const int durationInSeconds = 60 * 60 * 24;
        ctx.Context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.CacheControl] = 
            $"public, max-age={durationInSeconds}";
    }
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ensure database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        // Create the database if it doesn't exist
        dbContext.Database.EnsureCreated();
        
        // You can also use migrations if you have them set up
        // dbContext.Database.Migrate();
        
        Console.WriteLine("Database has been initialized.");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while initializing the database.");
    }
}

app.Run();
