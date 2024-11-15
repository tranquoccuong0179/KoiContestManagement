using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Repositories.Repository;
using KoiManagement_Service.Extension;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureManager();
builder.Services.ConfigureAutoMapper();
builder.Services.AddSession();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.ConfigureBlobService(builder.Configuration);
builder.Services.AddScoped<IMarkRepository, MarkRepository>();
builder.Services.AddScoped<IMarkService, MarkService>();
builder.Services.AddScoped<ICriteriaService, CriteriaService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPredictionService, PredictionService>();
builder.Services.AddScoped<ICompetitionService, CompetitionService>();
builder.Services.AddScoped<ICompetitionCategoryService, CompetitionCategoryService>();
builder.Services.AddScoped<ICompetitionRoundService, CompetitionRoundService>();
builder.Services.AddScoped<ICompetitionRoundRepository, CompetitionRoundRepository>();
builder.Services.AddScoped<IRoundService, RoundService>();
builder.Services.AddScoped<ICriteriaRepository, CriteriaRepository>();
builder.Services.AddScoped<IRefereeMarkRepository, RefereeMarkRepository>();
builder.Services.AddScoped<IRefereeMarkService, RefereeMarkService>();
builder.Services.AddScoped<ICriteriaPointRepository, CriteriaPointRepository>();
builder.Services.AddScoped<ICriteriaPointService, CriteriaPointService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();

builder.Services.AddScoped<IKoiService, KoiService>();
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<KoiManagementContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
