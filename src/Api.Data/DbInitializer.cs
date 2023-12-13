using System;
using System.Linq;
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

                    new ProfileEntity
                    {
                        Name = "Medico",
                        CreateAt = DateTime.UtcNow
                    },
                    new ProfileEntity
                    {
                        Name = "Paciente",
                        CreateAt = DateTime.UtcNow
                    }
                );
                context.SaveChanges();
            }
            // Se não houver nenhuma categoria de status na tabela StatusCategories, adicione as categorias iniciais
            if (!context.StatusCategories.Any())
            {
                context.StatusCategories.AddRange(
                    new StatusCategoryEntity
                    {
                        Status = "Agendada",
                        CreateAt = DateTime.UtcNow
                    },
                    new StatusCategoryEntity
                    {
                        Status = "Concluida",
                        CreateAt = DateTime.UtcNow
                    },
                    new StatusCategoryEntity
                    {
                        Status = "Cancelada",
                        CreateAt = DateTime.UtcNow
                    }
                );
                context.SaveChanges();
            }


        }
    }
}
