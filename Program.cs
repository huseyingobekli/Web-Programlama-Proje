var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP istek hattýný yapýlandýr
ConfigureApp(app);

app.Run(); // Uygulamayý çalýþtýr

void ConfigureApp(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        // Hata sayfasý ve HSTS kullan
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    // Ortak middleware'ler
    app.UseHttpsRedirection(); // HTTPS yönlendirme
    app.UseStaticFiles(); // Statik dosyalar

    app.UseRouting(); // Yönlendirme
    app.UseAuthorization(); // Yetkilendirme

    // Varsayýlan rota
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}
