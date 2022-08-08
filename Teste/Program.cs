using Microsoft.EntityFrameworkCore;
using Teste;
using Teste.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IDataService, DataService>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddTransient<IProdutoRepository,ProdutoRepository>();

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Services.GetService<IDataService>().InicializaDb();
//SUBSTITUIDO POR:
using (var scope = app.Services.CreateScope())
{
    //var _emailRepository = scope.ServiceProvider.GetRequiredService<IEmailRepository>();
    //var _repo =  scope.ServiceProvider.GetRequiredService<IDataService>().InicializaDb();
    var _repo = scope.ServiceProvider.GetRequiredService<IDataService>().InicializaDb;
    _repo.Invoke();

    //do your stuff....
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pedido}/{action=carrossel}/{codigo?}");

app.Run();
