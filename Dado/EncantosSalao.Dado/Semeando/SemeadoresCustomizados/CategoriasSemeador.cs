namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Modelos;

    public class CategoriasSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categorias.Any())
            {
                return;
            }

            var categorias = new Categoria[]
                {
                    new Categoria // Id = 1
                    {
                        Nome = "Cabeleireiro",
                        Descricao = "Corte seu cabelo conosco",
                        UrlImagem = ConstantesGlobais.Imagens.Cabelo,
                    },
                    new Categoria // Id = 1
                    {
                        Nome = "Spa",
                        Descricao = "Tratamento para pele",
                        UrlImagem = ConstantesGlobais.Imagens.Rosto,
                    },
                    new Categoria // Id = 1
                    {
                        Nome = "Maquiador",
                        Descricao = "Fazemos sua maquiagem",
                        UrlImagem = ConstantesGlobais.Imagens.Maquiador,
                    },
                    new Categoria // Id = 1
                    {
                        Nome = "Coloração",
                        Descricao = "As melhores técnicas de coloração",
                        UrlImagem = ConstantesGlobais.Imagens.Coloracao,
                    },
                };

            // Need them in particular order
            foreach (var categoria in categorias)
            {
                await dbContext.AddAsync(categoria);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
