using Azure.Identity;
using Mgmo.Main.Article.Data.Config;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}
else
{
    // Retrieve the connection string from the environment
    var connectionString = builder.Configuration.GetConnectionString("AppConfig");

    // Load the configuration settings from Azure App Configuration
    builder.Configuration.AddAzureAppConfiguration(connectionString);

    var keyVaultUri = builder.Configuration["AppSettings:KeyVaultUrl"];

    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());    
}

// Bind the configuration settings to the AppConfig class
builder.Services.Configure<AppConfig>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
