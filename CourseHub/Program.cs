using CourseHub.Core.Contracts;
using CourseHub.Core.Services;
using CourseHub.Infrastructure.Data.Models;
using CourseHub.Infrastrucure.Data;
using CourseHub.ModelBinders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CourseHubDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CourseHubDbContext>();

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IResultService, ResultService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRewriter(new RewriteOptions()
        .AddRewrite(@"^/Result/Add/^0-9/^a-zA-Z0-9\-", "/Result/Add/", skipRemainingRules: false) // Rewrite a specific URL pattern
);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Course Details",
        pattern: "/Course/Details/{id}/{information}",
        defaults: new { Controller = "Course", Action = "Details"}
    );
    endpoints.MapControllerRoute(
        name: "Result Add",
        pattern: "/Result/Add/{id}/{studentId}/{information}",
        defaults: new { Controller = "Result", Action = "Add" }
    );
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

await app.CreateAdminRoleAsync();
await app.RunAsync();
