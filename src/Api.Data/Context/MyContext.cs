using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<StatusCategory> StatusCategories { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<PatientHistory> PatientHistories { get; set; }

        // Construtor que aceita as opções do DbContext (usado para configurar a conexão com o banco de dados)
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade StatusCategory
            modelBuilder.Entity<StatusCategory>()
                .HasKey(sc => sc.IdStatus);

            // Configuração da entidade Profile
            modelBuilder.Entity<Profile>()
                .HasKey(p => p.IdProfile);

            // Configuração da entidade User
            modelBuilder.Entity<User>()
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.IdUser)
                .UseIdentityColumn(); // Autoincremento

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255); // Ajuste o tamanho conforme necessário

            modelBuilder.Entity<User>()
                .HasOne(u => u.ProfileStatus)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.Profile);

            // Configuração da entidade Doctor
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.IdDoctor);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.IdDoctor);

            // Configuração da entidade Patient
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.IdPatient);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.IdPatient);

            // Configuração da entidade Query
            modelBuilder.Entity<Query>()
                .HasKey(q => q.IdQuery);

            modelBuilder.Entity<Query>()
                .HasOne(q => q.StatusCategory)
                .WithMany()
                .HasForeignKey(q => q.Status)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Query>()
                .HasOne(q => q.Doctor)
                .WithMany(d => d.Queries)
                .HasForeignKey(q => q.IdDoctor);

            modelBuilder.Entity<Query>()
                .HasOne(q => q.Patient)
                .WithMany(p => p.Queries)
                .HasForeignKey(q => q.IdPatient);

            // Configuração da entidade PatientHistory
            modelBuilder.Entity<PatientHistory>()
                .HasKey(ph => new { ph.IdPatient, ph.IdQuery });

            modelBuilder.Entity<PatientHistory>()
                .HasOne(ph => ph.Patient)
                .WithMany(p => p.PatientHistories)
                .HasForeignKey(ph => ph.IdPatient);

            modelBuilder.Entity<PatientHistory>()
                .HasOne(ph => ph.Query)
                .WithMany(q => q.PatientHistories)
                .HasForeignKey(ph => ph.IdQuery);

            base.OnModelCreating(modelBuilder);
        }
    }
}
