using Entity_Layer.CustomClass;
using Data_Access_Layer.Migrations;
using Model_class.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<DoctorVM> tbl_Doctors { get; set; }
        public DbSet<Patient> tbl_Patients { get; set; }
        public DbSet<PatientDoctor> tbl_PatientDoctor { get; set; }
        public DbSet<PatientBill> tbl_PatientBill { get; set; }
        public DbSet<MedicalReport>tbl_medicalReports { get; set; }
        //public DbSet<patient1>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientDoctor>().HasKey(sc => new { sc.PatientId, sc.DoctorId });
            //foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            //}
            //modelBuilder.Entity<spSearchDoctorById>().HasNoKey().ToView(null);
        }
    }
}
