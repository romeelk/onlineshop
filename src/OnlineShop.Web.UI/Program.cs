using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database context
builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    // Create the database if it doesn't exist and seed initial data - This should never
    // run in produxtion. Seediing the db like this is daft.
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ShopContext>();
        context.Database.EnsureDeleted();
        //context.Database.EnsureCreated(); //- Can't be used with context.Database.Migrate()
        context.Database.Migrate();
        DbInitializer.Initialize(context);
    }
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
