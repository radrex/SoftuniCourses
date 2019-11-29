namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class HospitalContext : DbContext
    {
        //---------------- Constructors -----------------
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options) : base(options)
        {

        }

        //----------------- Properties ------------------
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        //------------------ Methods --------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePatientEntity(modelBuilder);
            ConfigureVisitationEntity(modelBuilder);
            ConfigureDiagnoseEntity(modelBuilder);
            ConfigureMedicamentEntity(modelBuilder);
            ConfigurePatientMedicamentEntity(modelBuilder);

            //-- TASK 02 -- Hospital Database Modification
            ConfigureDoctorEntity(modelBuilder);
        }

        private void ConfigurePatientEntity(ModelBuilder modelBuilder)
        {
            //---------------- PRIMARY KEY ------------------
            modelBuilder.Entity<Patient>()
                        .HasKey(p => p.PatientId);

            //---------------- FOREIGN KEYS -----------------
            modelBuilder.Entity<Patient>()
                        .HasMany(p => p.Visitations)
                        .WithOne(v => v.Patient)
                        .HasForeignKey(v => v.PatientId);

            modelBuilder.Entity<Patient>()
                        .HasMany(p => p.Diagnoses)
                        .WithOne(d => d.Patient)
                        .HasForeignKey(d => d.PatientId);

            //----------------- PROPERTIES ------------------
            modelBuilder.Entity<Patient>()
                        .Property(p => p.FirstName)
                        .HasMaxLength(50)
                        .IsRequired(true)
                        .IsUnicode(true);

            modelBuilder.Entity<Patient>()
                        .Property(p => p.LastName)
                        .HasMaxLength(50)
                        .IsRequired(true)
                        .IsUnicode(true);

            modelBuilder.Entity<Patient>()
                        .Property(p => p.Address)
                        .HasMaxLength(250)
                        .IsRequired(true)
                        .IsUnicode(true);

            modelBuilder.Entity<Patient>()
                        .Property(p => p.Email)
                        .HasMaxLength(80)
                        .IsRequired(false)
                        .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                        .Property(p => p.HasInsurance)
                        .IsRequired(true);
        }

        private void ConfigureVisitationEntity(ModelBuilder modelBuilder)
        {
            //---------------- PRIMARY KEY ------------------
            modelBuilder.Entity<Visitation>()
                        .HasKey(v => v.VisitationId);

            //----------------- PROPERTIES ------------------
            modelBuilder.Entity<Visitation>()
                        .Property(v => v.Date)
                        .IsRequired(true)
                        .HasColumnType("DATETIME2");

            modelBuilder.Entity<Visitation>()
                        .Property(v => v.Comments)
                        .HasMaxLength(250)
                        .IsRequired(false)
                        .IsUnicode(true);
        }

        private void ConfigureDiagnoseEntity(ModelBuilder modelBuilder)
        {
            //---------------- PRIMARY KEY ------------------
            modelBuilder.Entity<Diagnose>()
                        .HasKey(d => d.DiagnoseId);

            //----------------- PROPERTIES ------------------
            modelBuilder.Entity<Diagnose>()
                        .Property(d => d.Name)
                        .HasMaxLength(50)
                        .IsRequired(true)
                        .IsUnicode(true);

            modelBuilder.Entity<Diagnose>()
                        .Property(d => d.Comments)
                        .HasMaxLength(250)
                        .IsRequired(false)
                        .IsUnicode(true);
        }

        private void ConfigureMedicamentEntity(ModelBuilder modelBuilder)
        {
            //---------------- PRIMARY KEY ------------------
            modelBuilder.Entity<Medicament>()
                        .HasKey(m => m.MedicamentId);

            //----------------- PROPERTIES ------------------
            modelBuilder.Entity<Medicament>()
                        .Property(m => m.Name)
                        .HasMaxLength(50)
                        .IsRequired(true)
                        .IsUnicode(true);
        }

        private void ConfigurePatientMedicamentEntity(ModelBuilder modelBuilder)
        {
            //--------- PRIMARY KEY [COMPOSITE KEY] ---------
            modelBuilder.Entity<PatientMedicament>()
                        .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            //---------------- FOREIGN KEYS -----------------
            modelBuilder.Entity<PatientMedicament>()
                        .HasOne(pm => pm.Patient)
                        .WithMany(p => p.Prescriptions)
                        .HasForeignKey(pm => pm.PatientId);

            modelBuilder.Entity<PatientMedicament>()
                        .HasOne(pm => pm.Medicament)
                        .WithMany(m => m.Prescriptions)
                        .HasForeignKey(pm => pm.MedicamentId);
        }


        //-- TASK 02 -- Hospital Database Modification
        private void ConfigureDoctorEntity(ModelBuilder modelBuilder)
        {
            //---------------- PRIMARY KEY ------------------
            modelBuilder.Entity<Doctor>()
                        .HasKey(d => d.DoctorId);

            //---------------- FOREIGN KEYS -----------------
            modelBuilder.Entity<Doctor>()
                        .HasMany(d => d.Visitations)
                        .WithOne(v => v.Doctor)
                        .HasForeignKey(v => v.DoctorId);

            //----------------- PROPERTIES ------------------
            modelBuilder.Entity<Doctor>()
                        .Property(d => d.Name)
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .IsRequired(true);

            modelBuilder.Entity<Doctor>()
                        .Property(d => d.Specialty)
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .IsRequired(true);
        }
    }
}
