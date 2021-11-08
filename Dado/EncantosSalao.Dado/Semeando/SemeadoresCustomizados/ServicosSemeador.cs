namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Modelos;

    public class ServicosSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Servicos.Any())
            {
                return;
            }

            var servicos = new Servico[]
                {
                    new Servico
                    {
                        Nome = "Corte de cabelo femino",
                        Descricao = "Nunca subestime o poder de um ótimo corte de cabelo. Quer esteja à procura de bob, camadas ou corte, usando uma combinação de tesouras, lâminas de barbear e até mesmo tesouras de barbear, o seu cabeleireiro irá ajudá-lo a encontrar o seu look perfeito.",
                        IdCategoria = 1,
                    },
                    new Servico
                    {
                        Nome = "Secar",
                        Descricao = "Universalmente conhecido como o melhor amigo de todas as meninas, um secador de cabelo usa um secador de cabelo para aplicar ar quente nos cabelos úmidos, deixando-os macios, sedosos e sem frizz. Excelente para todos os tipos de cabelo, um secador de cabelo com elasticidade pode transformar seu visual em menos de 20 minutos, permitindo que você alcance uma textura que é quase impossível com a secagem natural ou ao ar.",
                        IdCategoria = 1,
                    },
                    new Servico
                    {
                        Nome = "Tintura de cabelo feminino",
                        Descricao = "A coloração do cabelo pode ser tão sutil ou exagerada quanto você quiser. Melhor feito no salão com um colorista habilidoso, as loiras podem ficar mais loiras, as morenas podem ser aumentadas, os cinzas podem ser cobertos ou realçados com uma mancha de cabelo de vovó. Sem mencionar que todas as cores malucas, do rosa ao azul e ao verde, podem ser obtidas nas mãos certas.",
                        IdCategoria = 1,
                    },
                    new Servico
                    {
                        Nome = "Extensões de cabelo",
                        Descricao = "Se você sonha com um cabelo volumoso e farto, mas luta para deixá-lo crescer além dos ombros ou precisa de um pouco de va-va-voom volumoso, deixe de lado os suplementos. Por que esperar meses pelos resultados quando você poderia obtê-los em um instante com extensões?",
                        IdCategoria = 1,
                    },
                    new Servico
                    {
                        Nome = "Corte de cabelo infantil",
                        Descricao = "O primeiro corte de cabelo do seu bebê pode ser um momento nervoso para pais e filhos, mas com a preparação certa, você pode transformar uma situação ríspida em um belo momento para vocês dois. Embora você possa estar emocionalmente deixando de lado essas mechas deliciosas, seu filho ficará mais assustado com muitos novos sons, visões e sensações. Não deixe que isso o desanime de tomá-los para o primeiro corte, basta um pouco de preparação ...",
                        IdCategoria = 1,
                    },
                    new Servico
                    {
                        Nome = "Corte de cabelo masculino",
                        Descricao = "Hoje em dia, os cortes de cabelo dos homens são tão variados quanto os das mulheres! Seja qual for o penteado que você escolher, o resultado final deve ser sempre o mesmo ao sair do salão de beleza: um corte de cabelo limpo e arrumado.",
                        IdCategoria = 1,
                    },
                    new Servico
                    {
                        Nome = "Coloração de cabelo masculino",
                        Descricao = "Claro, o visual da raposa prateada é sexy para muitas celebridades - mas, na realidade, a aparência pode ser muito mais cinza. Se você está precisando rejunvelecer ou simplesmente atrás de uma nova correção de cor, há muitos lugares por aí que oferecem coloração de cabelos.",
                        IdCategoria = 1,
                    },

                };

            // Ordena
            foreach (var servico in servicos)
            {
                await dbContext.AddAsync(servico);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
