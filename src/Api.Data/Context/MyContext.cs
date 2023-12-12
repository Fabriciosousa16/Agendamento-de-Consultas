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
        public DbSet<QueryPartientEntity> QueryPartients { get; set; }
        public DbSet<PatientHistoryEntity> PatientHistories { get; set; }

        // Construtor que aceita as opções do DbContext (usado para configurar a conexão com o banco de dados)
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.Profile)
            .WithMany()
            .HasForeignKey(u => u.IdProfile);

            modelBuilder.Entity<DoctorEntity>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.IdUser);

            modelBuilder.Entity<PatientEntity>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.IdUser);

            modelBuilder.Entity<QueryEntity>()
                .HasOne(q => q.Doctor)
                .WithMany()
                .HasForeignKey(q => q.IdDoctor);

            modelBuilder.Entity<QueryEntity>()
                .HasOne(q => q.Patient)
                .WithMany()
                .HasForeignKey(q => q.IdPatient);

            modelBuilder.Entity<QueryPartientEntity>()
                .HasOne(qp => qp.Status)
                .WithMany()
                .HasForeignKey(qp => qp.IdStatus);

            modelBuilder.Entity<QueryPartientEntity>()
                .HasOne(qp => qp.Doctor)
                .WithMany()
                .HasForeignKey(qp => qp.IdDoctor);

            modelBuilder.Entity<QueryPartientEntity>()
                .HasOne(qp => qp.Patient)
                .WithMany()
                .HasForeignKey(qp => qp.IdPatient);

            modelBuilder.Entity<PatientHistoryEntity>()
                .HasOne(ph => ph.Patient)
                .WithMany()
                .HasForeignKey(ph => ph.IdPatient);

            modelBuilder.Entity<PatientHistoryEntity>()
                .HasOne(ph => ph.Query)
                .WithMany()
                .HasForeignKey(ph => ph.IdQuery);

            // Definindo autoincremento e unicidade para IdStatus
            modelBuilder.Entity<StatusCategoryEntity>()
                .Property(s => s.IdStatus)
                .ValueGeneratedOnAdd();

            // Definindo autoincremento e unicidade para IdProfile
            modelBuilder.Entity<ProfileEntity>()
                .Property(p => p.IdProfile)
                .ValueGeneratedOnAdd();

            // Definindo autoincremento, unicidade e tamanho máximo para Email
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.IdUser)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.CPF)
                .IsUnique();

            // Definindo autoincremento para IdDoctor
            modelBuilder.Entity<DoctorEntity>()
                .Property(d => d.IdDoctor)
                .ValueGeneratedOnAdd();

            // Definindo autoincremento para IdPatient
            modelBuilder.Entity<PatientEntity>()
                .Property(p => p.IdPatient)
                .ValueGeneratedOnAdd();

            // Definindo autoincremento para IdQuery
            modelBuilder.Entity<QueryEntity>()
                .Property(q => q.IdQuery)
                .ValueGeneratedOnAdd();

            // Definindo autoincremento para IdQueryPartient
            modelBuilder.Entity<QueryPartientEntity>()
                .Property(qp => qp.IdQueryPartient)
                .ValueGeneratedOnAdd();

            // Definindo autoincremento para IdHistory
            modelBuilder.Entity<PatientHistoryEntity>()
                .Property(ph => ph.IdHistory)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<StatusCategoryEntity>()
                .HasKey(s => s.IdStatus);

            modelBuilder.Entity<ProfileEntity>()
                .HasKey(p => p.IdProfile);

            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<DoctorEntity>()
                .HasKey(d => d.IdDoctor);

            modelBuilder.Entity<PatientEntity>()
                .HasKey(p => p.IdPatient);

            modelBuilder.Entity<QueryEntity>()
                .HasKey(q => q.IdQuery);

            modelBuilder.Entity<QueryPartientEntity>()
                .HasKey(qp => qp.IdQueryPartient);

            modelBuilder.Entity<PatientHistoryEntity>()
                .HasKey(ph => ph.IdHistory);

            base.OnModelCreating(modelBuilder);
        }
    }
}
