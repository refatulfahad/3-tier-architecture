using Business_Logic_Layer;
using Data_Access_Layer;
using Data_Access_Layer.InterfaceDAL;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Business_Logic_Layer.InterfaceBLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IDoctorBLL, DoctorBLL>();
builder.Services.AddScoped<IDoctorDAL, DoctorDAL>();

builder.Services.AddScoped<IPatientBLL, PatientBLL>();
builder.Services.AddScoped<IPatientDAL, PatientDAL>();

builder.Services.AddScoped<IPatientBillBLL, PatientBillBLL>();
builder.Services.AddScoped<IPatientBillDAL, PatientBillDAL>();

builder.Services.AddScoped<IMedicalReportBLL, MedicalReportBLL>();
builder.Services.AddScoped<IMedicalReportDAL, MedicalReportDAL>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddCors((option) =>
{
    option.AddPolicy("default", (builder) => {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");
app.UseAuthorization();

app.MapControllers();

app.Run();
