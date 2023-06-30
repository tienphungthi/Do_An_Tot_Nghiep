using Microsoft.EntityFrameworkCore;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using QlLopHocSinhVien.Service;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IsGenericRepository<>), typeof(SGenericRepository<>));

builder.Services.AddScoped<IChuongTrinhHocService, ChuongTrinhHocService>();
builder.Services.AddScoped<IKhoaHocService, KhoaHocService>();
builder.Services.AddScoped<ICoSoService, CoSoService>();
builder.Services.AddScoped<ILopHocService, LopHocService>();
builder.Services.AddScoped<ITaiKhoanService, TaiKhoanService>();
builder.Services.AddScoped<INhanVienService, NhanVienService>();
builder.Services.AddScoped<IPhongBanService, PhongBanService>();
builder.Services.AddScoped<IChucVuService, ChucVuService>();
builder.Services.AddScoped<ITrinhDoService,TrinhDoService>();  
builder.Services.AddScoped<IGiangVienService,GiangVienService>();
builder.Services.AddScoped<IQLThiService, QLThiService>();
builder.Services.AddScoped<IDangKiHocService, DangKiHocService>();
builder.Services.AddScoped<IHocVienService, HocVienService>();
builder.Services.AddScoped<IDiemDanhService, DiemDanhService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GreenEduContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
