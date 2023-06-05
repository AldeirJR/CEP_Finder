using DevAldeir.AppCEP_Finder.Sevice;
using System.ComponentModel.Design;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddScoped<ICEPService, CEPService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}" );

app.MapControllerRoute(
       name: "viacep",
       pattern: "ViaCep/{action}",
       defaults: new { controller = "CEP" });

app.MapControllerRoute(
    name: "gerarEtiqueta",
    pattern: "Etiqueta/{action}",
    defaults: new { controller = "Etiqueta" });




app.Run();
