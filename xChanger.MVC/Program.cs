using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using xChanger.MVC.Brokers.DateTimes;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Brokers.Storages;
using xChanger.MVC.Brokers;
using xChanger.MVC.Services.Foundations.Applicants;
using xChanger.MVC.Services.Foundations.Group;
using xChanger.MVC.Services.Foundations.SpreadSheet;
using xChanger.MVC.Services.Orchestrations;
using xChanger.MVC.Services.Proccesings.Applicants;
using xChanger.MVC.Services.Proccesings.Group;
using xChanger.MVC.Services.Proccesings.SpreadSheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<StorageBroker>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StorageBroker>();
builder.Services.AddSingleton<IStorageBroker, StorageBroker>();
builder.Services.AddSingleton<IOrchestrationService, OrchestrationService>();
builder.Services.AddSingleton<ISpreadsheetProccesingService, SpreadsheetProccesingService>();
builder.Services.AddSingleton<ISpreadSheetBroker, SpreadSheetBroker>();
builder.Services.AddSingleton<ISpreadsheetService, SpreadsheetService>();
builder.Services.AddSingleton<ILoggingBroker, LoggingBroker>();
builder.Services.AddSingleton<IGroupProccesingService, GroupProccesingService>();
builder.Services.AddSingleton<IGroupService, GroupService>();
builder.Services.AddSingleton<IApplicantProccesingService, ApplicantProccesingService>();
builder.Services.AddSingleton<IApplicantService, ApplicantService>();
builder.Services.AddSingleton<IDateTimeBroker, DateTimeBroker>();
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
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
