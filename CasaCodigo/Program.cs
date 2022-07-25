using CasaCodigo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();  

//builder.Services.AddTransient<ICatalago, Catalago>();
//builder.Services.AddTransient<IRelatorio, Relatorio>();

//builder.Services.AddScoped<ICatalago, Catalago>();
//builder.Services.AddScoped<IRelatorio, Relatorio>();

builder.Services.AddSingleton<ICatalago, Catalago>();
builder.Services.AddSingleton<IRelatorio, Relatorio>();

var app = builder.Build();

ICatalago catalago = app.Services.GetService<ICatalago>();
IRelatorio relatorio = app.Services.GetService<IRelatorio>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
