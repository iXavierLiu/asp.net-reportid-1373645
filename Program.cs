using Microsoft.AspNetCore.Mvc.Razor;
using Report;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // ͨ�������ռ��Զ�����Ŀ¼�з���View��ͼ
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
