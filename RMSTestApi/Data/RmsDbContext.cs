
using Microsoft.EntityFrameworkCore;
using RMSTestApi.Models;


namespace RMSTestApi.Data
{
    public class RmsDbContext: DbContext
    {

        protected readonly IConfiguration _configuration;
   

    protected override void  OnConfiguring(DbContextOptionsBuilder options)
    {

        string ? conn= @"Server=H505495\SQLEXPRESS;Database=RMS;user id=sa;password=sa@1234;TrustServerCertificate=True";

        options.UseSqlServer(conn);

    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Referral> Referrals { get; set; }
    public DbSet<Specialty> Specialties { get; set; }

    }
}
