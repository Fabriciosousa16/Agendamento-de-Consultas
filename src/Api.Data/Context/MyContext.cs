using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<StatusCategoryEntity> StatusCategories { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<QueryEntity> Queries { get; set; }
        public DbSet<PatientHistoryEntity> PatientHistories { get; set; }

        // Construtor que aceita as opções do DbContext (usado para configurar a conexão com o banco de dados)
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade StatusCategory
            modelBuilder.Entity<StatusCategoryEntity>()
                .HasKey(sc => sc.IdStatus);

            // Configuração da entidade Profile
            modelBuilder.Entity<ProfileEntity>()
                .HasKey(p => p.IdProfile);

            // Configuração da entidade User
            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<UserEntity>()
                .Property(u => u.IdUser)
                .UseIdentityColumn(); // Autoincremento

            modelBuilder.Entity<UserEntity>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255); // Ajuste o tamanho conforme necessário

            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.ProfileStatus)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.Profile);

            // Configuração da entidade Doctor
            modelBuilder.Entity<DoctorEntity>()
                .HasKey(d => d.IdDoctor);

            modelBuilder.Entity<DoctorEntity>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<DoctorEntity>(d => d.IdDoctor);

            // Configuração da entidade Patient
            modelBuilder.Entity<PatientEntity>()
                .HasKey(p => p.IdPatient);

            modelBuilder.Entity<PatientEntity>()
                .HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<PatientEntity>(p => p.IdPatient);

            // Configuração da entidade Query
            modelBuilder.Entity<QueryEntity>()
                .HasKey(q => q.IdQuery);

            modelBuilder.Entity<QueryEntity>()
                .HasOne(q => q.StatusCategory)
                .WithMany()
                .HasForeignKey(q => q.Status)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QueryEntity>()
                .HasOne(q => q.Doctor)
                .WithMany(d => d.Queries)
                .HasForeignKey(q => q.IdDoctor);

            modelBuilder.Entity<QueryEntity>()
                .HasOne(q => q.Patient)
                .WithMany(p => p.Queries)
                .HasForeignKey(q => q.IdPatient);

            // Configuração da entidade PatientHistory
            modelBuilder.Entity<PatientHistoryEntity>()
                .HasKey(ph => new { ph.IdPatient, ph.IdQuery });

            modelBuilder.Entity<PatientHistoryEntity>()
                .HasOne(ph => ph.Patient)
                .WithMany(p => p.PatientHistories)
                .HasForeignKey(ph => ph.IdPatient);

            modelBuilder.Entity<PatientHistoryEntity>()
                .HasOne(ph => ph.Query)
                .WithMany(q => q.PatientHistories)
                .HasForeignKey(ph => ph.IdQuery);

            base.OnModelCreating(modelBuilder);
        }
    }
}
