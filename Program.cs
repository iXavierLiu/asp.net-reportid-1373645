using Microsoft.AspNetCore.Mvc.Razor;
using Report;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // 通过命名空间自动在子目录中发现View视图
    options.ViewLocationExpanders.Add(new NamespaceViewLocationExpander(new List<string> { @"/Views/{namespace}/{1}/{0}.cshtml" }, @"{namespace}"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
