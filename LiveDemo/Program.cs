using LiveDemo.ActionFilters;
using LiveDemo.Models;
using LiveDemo.Services;
using LiveDemo.ValidationAttributes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(builder =>
{
    builder.Filters.Add<�p��C�ӭ�������ڰ���ɶ�Attribute>();
});

builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<MyService>();

builder.Services.AddScoped<�P�_�O�_�����ƪ��ҵ{�W��Attribute>();

builder.Services.AddScoped<�p��C�ӭ�������ڰ���ɶ�Attribute>();

builder.Services.AddDbContext<ContosoUniversityContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
