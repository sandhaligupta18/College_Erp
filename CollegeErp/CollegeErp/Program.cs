using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDB_Context>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<RegisterUser,IdentityRole>()
    .AddEntityFrameworkStores<AppDB_Context>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ITeacherOperations, TeacherOperations>();

builder.Services.AddScoped<IStudentOperations, StudentOperations>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<IFeeStructureServices, FeeStructureServices>();
builder.Services.AddScoped<ILibraryServices,LibraryServices>();
builder.Services.AddScoped<IHostelServices, HostelServices>();
builder.Services.AddScoped<ITimeTableServices, TimeTableServices>();
builder.Services.AddScoped<IAssignmentServicescs, AssignmentServices>();
builder.Services.AddScoped<IAssignmentsServices, AssignmentsServices>();


builder.Services.AddSession();
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
app.UseSession();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=CheckUsers}/{id?}");

app.Run();
