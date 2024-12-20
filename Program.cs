var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP istek hattýný yapýlandýr
if (!app.Environment.IsDevelopment())
{
    // Hata sayfasý ve HSTS kullan
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // HTTPS yönlendirme
app.UseStaticFiles(); // Statik dosyalar

app.UseRouting(); // Yönlendirme

app.UseAuthorization(); // Yetkilendirme

// Varsayýlan rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Uygulamayý çalýþtýr
