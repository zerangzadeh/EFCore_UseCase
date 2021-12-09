using EFCore.Application;
using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductAgg;
using EFCore.Domain.ProductCategoryAgg;
using EFCore.Infrastracture;
using EFCore.Infrastracture.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductApplication, ProductApplication>();
builder.Services.AddDbContext<EFContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreProduct")));

builder.Services.AddRazorPages();

var app = builder.Build();

//Configure the HTTP request pipeline.
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
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});

app.Run();

