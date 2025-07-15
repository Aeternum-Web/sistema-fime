using Microsoft.EntityFrameworkCore;
using SistemaFIME.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configurar Entity Framework con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Esperar a que PostgreSQL esté listo y aplicar migraciones
if (app.Environment.IsDevelopment())
{
    await WaitForDatabase(app.Services, app.Logger);
    
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
    }
}

static async Task WaitForDatabase(IServiceProvider services, ILogger logger)
{
    using var scope = services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
    var maxRetries = 30;
    var delay = TimeSpan.FromSeconds(2);
    
    for (int i = 0; i < maxRetries; i++)
    {
        try
        {
            logger.LogInformation($"Intentando conectar a la base de datos... Intento {i + 1}/{maxRetries}");
            await context.Database.CanConnectAsync();
            logger.LogInformation("✅ Conexión a la base de datos establecida exitosamente");
            return;
        }
        catch (Exception ex)
        {
            logger.LogWarning($"❌ Error conectando a la base de datos (intento {i + 1}/{maxRetries}): {ex.Message}");
            
            if (i == maxRetries - 1)
            {
                logger.LogError("💥 No se pudo conectar a la base de datos después de todos los intentos");
                throw;
            }
            
            await Task.Delay(delay);
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
