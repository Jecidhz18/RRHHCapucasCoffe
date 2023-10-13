using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddTransient<IRepositorioPais, RepositorioPais>();
builder.Services.AddTransient<IRepositorioDepartamento, RepositorioDepartamento>(); 
builder.Services.AddTransient<IRepositorioColegioProfesional, RepositorioColegioProfesional>();
builder.Services.AddTransient<IRepositorioEstadoCivil,  RepositorioEstadoCivil>();
builder.Services.AddTransient<IRepositorioRemuneracion, RepositorioRemuneracion>();
builder.Services.AddTransient<IRepositorioUnidad, RepositorioUnidad>();
builder.Services.AddTransient<IRepositorioProfesion, RepositorioProfesion>(); 
builder.Services.AddTransient<IRepositorioBanco, RepositorioBanco>();
builder.Services.AddTransient<IRepositorioCargo, RepositorioCargo>();   
builder.Services.AddTransient<IRepositorioPaisDepto, RepositorioPaisDepto>();
builder.Services.AddTransient<IRepositorioMunicipio, RepositorioMunicipio>();
builder.Services.AddTransient<IRepositorioDeptoMunicipio, RepositorioDeptoMunicipio>();
builder.Services.AddTransient<IRepositorioAldea, RepositorioAldea>();
builder.Services.AddTransient<IRepositorioMpioAldea, RepositorioMpioAldea>();
builder.Services.AddTransient<IRepositorioDeduccion, RepositorioDeduccion>();
builder.Services.AddTransient<IRepositorioAgencia, RepositorioAgencia>();
builder.Services.AddTransient<IRepositorioAgenciaUnidad, RepositorioAgenciaUnidad>();
builder.Services.AddTransient<IRepositorioModalidad, RepositorioModalidad>();
builder.Services.AddTransient<IRepositorioEmpleado, RepositorioEmpleado>();
builder.Services.AddTransient<IRepositorioDireccionEmpleado, RepositorioDireccionEmpleado>();
builder.Services.AddTransient<IRepositorioFamiliar, RepositorioFamiliar>();
builder.Services.AddTransient<IRepositorioEmpleadoBanco, RepositorioEmpleadoBanco>();
builder.Services.AddTransient<IRepositorioEmpleadoColegiacion, RepositorioEmpleadoColegiacion>();
builder.Services.AddTransient<IRepositorioEmpleadoArea, RepositorioEmpleadoArea>();
builder.Services.AddTransient<IRepositorioEmpleadoCargo, RepositorioEmpleadoCargo>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
