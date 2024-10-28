using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.OpenApi.Models;
using SUO.BusinessActions.AddEntidades;
using SUO.BusinessActions.AddPerfilUsuario;
using SUO.BusinessActions.DeletePerfilUsuario;
using SUO.BusinessActions.EstadoPerfil;
using SUO.BusinessActions.FichaPaciente;
using SUO.BusinessActions.ListaEntidadByIdRut;
using SUO.BusinessActions.ListaEntidades;
using SUO.BusinessActions.ListaImgCarrusel;
using SUO.BusinessActions.ListaPerfilUsuario;
using SUO.BusinessActions.ListaPerfilUsuarioByIdRut;
using SUO.BusinessActions.ListaRutNombreEntidad;
using SUO.BusinessActions.LoginUsers;
using SUO.BusinessActions.Pacientes;
using SUO.BusinessActions.RegionesComunas;
using SUO.BusinessActions.TipoPerfil;
using SUO.BusinessActions.UpdEntidad;
using SUO.BusinessActions.UpdPerfilUsuario;
using SUO.BusinessObjects.UpdEntidad;
using SUO.DataAccessLayer;
using SUO.DataAccessLayer.Repositories.AddEntidades;
using SUO.DataAccessLayer.Repositories.AddPerfilUsuario;
using SUO.DataAccessLayer.Repositories.DeletePerfilUsuario;
using SUO.DataAccessLayer.Repositories.EstadoPerfil;
using SUO.DataAccessLayer.Repositories.FichaPaciente;
using SUO.DataAccessLayer.Repositories.ListaEntidadByIdRut;
using SUO.DataAccessLayer.Repositories.ListaEntidades;
using SUO.DataAccessLayer.Repositories.ListaImgCarrusel;
using SUO.DataAccessLayer.Repositories.ListaPerfilUsuario;
using SUO.DataAccessLayer.Repositories.ListaPerfilUsuarioByIdRut;
using SUO.DataAccessLayer.Repositories.ListaRutNombreEntidad;
using SUO.DataAccessLayer.Repositories.LoginUsers;
using SUO.DataAccessLayer.Repositories.Pacientes;
using SUO.DataAccessLayer.Repositories.RegionesComunas;
using SUO.DataAccessLayer.Repositories.TipoPerfil;
using SUO.DataAccessLayer.Repositories.UpdEntidad;
using SUO.DataAccessLayer.Repositories.UpdPerfilUsuario;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews(); 


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApplicationSUO API", Version = "v1" });
});


var sqlConfiguration = new SQLConfiguration(builder.Configuration.GetConnectionString("SQLConnection"));
var rutaArchivo = new RutaArchivoConfiguration(builder.Configuration.GetConnectionString("RutaArchivoImagen"));
builder.Services.AddSingleton(rutaArchivo);
builder.Services.AddSingleton(sqlConfiguration);


builder.Services.AddScoped<ILoginUsersRepository, LoginUsersRepository>();
builder.Services.AddScoped<IPacientesRepository, PacientesRepository>();
builder.Services.AddScoped<IFichaPacienteRepository, FichaPacienteRepository>();
builder.Services.AddScoped<ITipoPerfilRepository, TipoPerfilRepository>();
builder.Services.AddScoped<IEstadoPerfilRepository, EstadoPerfilRepository>();
builder.Services.AddScoped<IRegionesComunasRepository, RegionesComunasRepository>();
builder.Services.AddScoped<IListaRutNombreEntidadRepository, ListaRutNombreEntidadRepository>();
builder.Services.AddScoped<IAddPerfilUsuarioRepository, AddPerfilUsuarioRepository>();
builder.Services.AddScoped<IListaPerfilUsuarioRepository, ListaPerfilUsuarioRepository>();
builder.Services.AddScoped<IListaPerfilUsuarioByIdRutRepository, ListaPerfilUsuarioByIdRutRepository>();
builder.Services.AddScoped<IUpdPerfilUsuarioRepository, UpdPerfilUsuarioRepository>();
builder.Services.AddScoped<IDeletePerfilUsuarioRepository, DeletePerfilUsuarioRepository>();
builder.Services.AddScoped<IListaEntidadesRepository, ListaEntidadesRepository>();
builder.Services.AddScoped<IAddEntidadesRepository, AddEntidadesRepository>();
builder.Services.AddScoped<IListaEntidadByIdRutRepository, ListaEntidadByIdRutRepository>();
builder.Services.AddScoped<IListaImgCarruselRepository, ListaImgCarruselRepository>();
builder.Services.AddScoped<IUpdEntidadRepository, UpdEntidadRepository>();


builder.Services.AddScoped<LoginUserAction>();
builder.Services.AddScoped<PacientesAction>();
builder.Services.AddScoped<FichaPacienteAction>();
builder.Services.AddScoped<TipoPerfilAction>();
builder.Services.AddScoped<EstadoPerfilAction>();
builder.Services.AddScoped<RegionesComunasAction>();
builder.Services.AddScoped<ListaRutNombreEntidadAction>();
builder.Services.AddScoped<AddPerfilUsuarioAction>();
builder.Services.AddScoped<ListaPerfilUsuarioAction>();
builder.Services.AddScoped<ListaPerfilUsuarioByIdRutAction>();
builder.Services.AddScoped<ActualizaPerfilUsuarioAction>();
builder.Services.AddScoped<DeletePerfilUsuarioAction>();
builder.Services.AddScoped<ListaEntidadesAction>();
builder.Services.AddScoped<AddEntidadesAction>();
builder.Services.AddScoped<ListaEntidadByIdRutAction>();
builder.Services.AddScoped<ListaImgCarruselAction>();
builder.Services.AddScoped<UpdEntidadAction>();
//builder.Services.AddScoped<GeneraPDFAction>();


builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApplicationSUO.Com.ApplicationSUOWebApi.Bcl v1.0"));

app.UseHttpsRedirection();
app.UseRouting(); 
app.UseAuthorization(); 

app.MapControllers(); 

app.Run(); 
