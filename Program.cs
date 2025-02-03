var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Aktivera MVC-mönster
builder.Services.AddSession(); // Aktivera session

var app = builder.Build(); // Bygg applikationen


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
  
    app.UseHsts();
}

app.UseSession(); // Använd session
app.UseHttpsRedirection();
app.UseRouting(); // Routing

app.UseAuthorization();

app.MapStaticAssets();

// Routing-konfigurering
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}") // Sökmönster för URL 
    .WithStaticAssets();


app.Run(); // Starta applikationen 
