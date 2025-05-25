// Import custom namespaces for data access and middleware
using folder_structure.Data;
using folder_structure.Middelware;

// Import ASP.NET Core Identity and EF Core for authentication and database context
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // Create a builder to configure the app's services and middleware

// Get the connection string from appsettings.json or throw an error if not found
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register ApplicationDbContext with the dependency injection container using SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    
options.UseSqlServer(connectionString));

// Add support for developer-friendly database error pages
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure default Identity system with account confirmation required
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Register services for MVC controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build(); // Build the app with all the configured services

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // In development, show detailed database errors
    app.UseMigrationsEndPoint();
}
else
{
    // In production, use a generic error handler and HSTS (HTTP Strict Transport Security)
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Add custom middleware that returns "Hello World"
app.UseMiddleware<HelloWorldMiddleware>();

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Serve static files (e.g., CSS, JS, images) from wwwroot
 app.UseStaticFiles();

// Enable routing for controllers and Razor pages
app.UseRouting();

app.UseAuthentication();

// Enable authorization middleware (checks if users are authorized)
app.UseAuthorization();


// Enable CORS (Cross-Origin Resource Sharing) for external access if configured
app.UseCors();

// Use custom error handling middleware to catch and manage application errors
//app.UseMiddleware<ErrorHandlerMiddelware>();

// Define the default routing pattern for MVC: Home controller and Index action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages endpoints (for pages in /Pages folder)
  app.MapRazorPages();

app.Run(); // Run the app
