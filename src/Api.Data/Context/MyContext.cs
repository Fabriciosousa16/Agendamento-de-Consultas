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
        public DbSet<Category> Categories { get; set; }
        public DbSet<TypeCategory> TypeCategories { get; set; }
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
            // Configurações adicionais do modelo, como chaves primárias compostas, índices, etc.
            // Exemplo:
            modelBuilder.Entity<TypeCategory>()
                .HasKey(tc => tc.IdTypeCategory);

            modelBuilder.Entity<TypeCategory>()
                .HasOne(tc => tc.Category)
                .WithMany(c => c.TypeCategories)
                .HasForeignKey(tc => tc.IdCategory);

            // Adicione outras configurações aqui...

            base.OnModelCreating(modelBuilder);
        }
    }
}
