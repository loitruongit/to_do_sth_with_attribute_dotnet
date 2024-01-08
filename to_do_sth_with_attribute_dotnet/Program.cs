using to_do_sth_with_attribute_dotnet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddOpenApiDocument(configure =>
{
    configure.Title = "Demo - Todo sth with attribute";
});

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
app.UseOpenApi();
app.UseSwaggerUi3(settings =>
{
    settings.Path = "/api";
});

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
