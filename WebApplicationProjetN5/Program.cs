using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplicationProjetN5.Data;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Implementation;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.Services.Implementations;
using WebApplicationProjetN5.Models.Services.Interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<ApplicationUser>() //IdentityUser
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GarageDBContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddRazorPages();

//Implementation of servce and repository interface (dependency injection)

builder.Services.AddDbContext<GarageDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GarageDbLocalConnection")));
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

builder.Services.AddScoped<ICarModelService, CarModelService>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();

builder.Services.AddScoped<ICarFinishService, CarFinishService>();
builder.Services.AddScoped<ICarFinishRepository, CarFinishRepository>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddScoped<IReparationRepository, ReparationRepository>();
builder.Services.AddScoped<IReparationService, ReparationService>();



//**********************************
//French Culture Management
var cultureInfo = new CultureInfo("fr-FR");

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(cultureInfo),
    SupportedCultures = new[] { cultureInfo },
    SupportedUICultures = new[] { cultureInfo }
};


//Building application from the service configuration
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    await IdentitySeeder.CreateAdminAsync(
        scope.ServiceProvider,
        builder.Configuration);
}

//************************
/*using (var context = new GarageDBContext())
{
   
    //creates db if not exists 
    context.Database.EnsureCreated();



    /*
    //create entity objects
    var Inventory= new Inventory() { Cars = new List<Car>() };
    var Role1 = new Role() { Libelle = "Admin", Users = new List<User>() };
    var Brand1= new Brand() { Name = "Peugeot", CarModels = new List<CarModel>() };
    var CarModel1= new CarModel() { Name="308", Brand=Brand1, BrandId=Brand1.Id, CarVersions = new List<CarVersion>() };
    var Carversion1 = new CarVersion() { CarFinish="Allure", ReleasedYear=2020, CarModel = CarModel1, CarModelId = CarModel1.Id, Cars = new List<Car>() };
    var Us1 = new User() { Cars = new List<Car>(), Role = Role1, Name = "John Doe", RoleId = Role1.Id };
    var Car1 = new Car() {  Availability = true, CarVersion = Carversion1, CarVersionId = 1, Inventory = Inventory, InventoryId = 1, Reparations = new List<Reparation>(), User = Us1, UserId = Us1.Id };
    var Ann1 = new Announce() { Description = "Sample announce description", Photo = "sample.jpg", Car= Car1, CarId = Car1.Id, Visitors= new List<Visitor>() };
    var DateComponent1= new DateComponent() { Car=Car1, CarId=Car1.Id, PurchaseDate = DateOnly.Parse("27/04/2020"), SaleAvailableDate = DateOnly.Parse("27/04/2021"), SaleDate= DateOnly.Parse("30/07/2026")};
    var FinancialComponent1= new FinancialComponent() { Car=Car1, CarId=Car1.Id, PurchasePrice = 20000, ReparationCost = 5000, SellingPrice=25000};
    var Visitor1= new Visitor() { Announces= new List<Announce>() };
    
    //add entity to the context
    context.Inventory.Add(Inventory);
    context.Roles.Add(Role1);
    context.Brands.Add(Brand1);
    context.CarModels.Add(CarModel1);
    context.CarVersions.Add(Carversion1);
    context.Users.Add(Us1);
    context.Cars.Add(Car1);
    context.Announces.Add(Ann1);
    context.DateComponents.Add(DateComponent1);
    context.FinancialComponents.Add(FinancialComponent1);
    context.Visitors.Add(Visitor1); 
    

    //save data to the database tables
    context.SaveChanges();
    /*
    //retrieve all the students from the database
    foreach (var s in context.CarVersions)
    {
        Console.WriteLine($"CarFinish: {s.CarFinish}, ReleasedYear: {s.ReleasedYear}");
    }

    DisplayStates(context.ChangeTracker.Entries());
  
}
    


static void DisplayStates(IEnumerable<EntityEntry> entries)
{
    foreach (var entry in entries)
    {
        Console.WriteLine($"Entity: {entry.Entity.GetType().Name} State: { entry.State.ToString()} ");
    }
}*/
app.UseRequestLocalization(localizationOptions);

//************************
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Car}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
