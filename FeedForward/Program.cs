using FeedForwardRepository.Abstract;
using FeedForwardRepository.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(120);
});

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserManagmentRepository, UserManagmentRepository>();
builder.Services.AddSingleton<IFeedBackSchedulingRepository, FeedBackSchedulingRepository>();
builder.Services.AddSingleton<ISubmittingFeedbackRepository, SubmittingFeedbackRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/UserManagment/UserLogin";
                    option.AccessDeniedPath = "/UserManagment/UserLogin";
                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserManagment}/{action=UserLogin}/{id?}");

app.Run();
