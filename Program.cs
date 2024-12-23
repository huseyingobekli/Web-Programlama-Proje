var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP istek hatt�n� yap�land�r
ConfigureApp(app);

app.Run(); // Uygulamay� �al��t�r

void ConfigureApp(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        // Hata sayfas� ve HSTS kullan
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    // Ortak middleware'ler
    app.UseHttpsRedirection(); // HTTPS y�nlendirme
    app.UseStaticFiles(); // Statik dosyalar

    app.UseRouting(); // Y�nlendirme
    app.UseAuthorization(); // Yetkilendirme

    // Varsay�lan rota
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}
