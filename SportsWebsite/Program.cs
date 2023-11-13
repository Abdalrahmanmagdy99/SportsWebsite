using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using SportsWebsite.Middlewares;
using SprotsWebsite.Data.Repository;
using SprotsWebsite.Domain.DbContexts;
using SprotsWebsite.Domain.Entities;
using SprotsWebsite.Services;
using User = SprotsWebsite.Domain.Entities.User;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<SprotsWebsiteDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<SprotsWebsiteDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    PopulateData();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseMiddleware<GlobalExceptionHandler>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
void PopulateData()
{
    string sqlConnectionString = @"Server=(localdb)\\mssqllocaldb;Database=aspnet-SprotsWebsite-8a8ad126-c42c-4008-a0ab-7b5e713cd456;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true";
    string workingDirectory = Environment.CurrentDirectory;
    string path = Path.Combine(Directory.GetParent(workingDirectory).FullName, "SportsWebsite.Domain","Scripts", @"SportsWebsite-Script.sql");
    string script = File.ReadAllText(path);

    SqlConnection conn = new SqlConnection(sqlConnectionString);

    Server server = new Server(new ServerConnection(conn));

    server.ConnectionContext.ExecuteNonQuery(script);
}