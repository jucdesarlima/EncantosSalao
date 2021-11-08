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
                        Nome = "Salões de Cabeleireiro",
                        Descricao = "Salões de Cabeleireiro vêm em uma variedade de formas e tamanhos. Se você prefere fazer alarde em compromissos de cabelo regulares ou gosta de cortar e mudar de acordo com sua localização e seu orçamento, uma coisa é certa - todos nós precisamos de um bom corte de vez em quando e um salão de cabeleireiro é o lugar para fazê-lo.",
                        UrlImagem = ConstantesGlobais.Imagens.Cabelo,
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
