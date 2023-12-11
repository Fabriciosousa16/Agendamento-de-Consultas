using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;

namespace Api.Data
{
    public class DbInitializer
    {
        public static void Initialize(MyContext context)
        {
            context.Database.EnsureCreated();

            // Se não houver nenhum perfil na tabela Profiles, adicione os perfis iniciais
            if (!context.Profiles.Any())
            {
                context.Profiles.AddRange(
                    new ProfileEntity { Name = "Medico" },
                    new ProfileEntity { Name = "Paciente" }
                );
                context.SaveChanges();
            }

            // Se não houver nenhuma categoria de status na tabela StatusCategories, adicione as categorias iniciais
            if (!context.StatusCategories.Any())
            {
                context.StatusCategories.AddRange(
                    new StatusCategoryEntity { Status = "Agendada" },
                    new StatusCategoryEntity { Status = "Concluida" },
                    new StatusCategoryEntity { Status = "Cancelada" }
                );
                context.SaveChanges();
            }
        }
    }
}
