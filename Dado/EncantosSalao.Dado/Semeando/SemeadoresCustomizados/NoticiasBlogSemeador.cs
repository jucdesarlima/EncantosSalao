namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Modelos;

    public class NoticiasBlogSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.NoticiasBlog.Any())
            {
                return;
            }

            var blogPosts = new NoticiasBlog[]
                {
                    new NoticiasBlog // Id = 1
                    {
                        Title = "Dicas de beleza de verão",
                        Content = @"Use produtos não comedogênicos. Os produtos de beleza não comedogênicos são desenvolvidos para não obstruir os poros, o que pode causar irritação e manchas. É importante lembrar disso para os protetores solares, mas pode afetar você mais se você hidratar com frequência e tiver tendência a acne - especialmente no verão. O tempo quente e úmido leva ao suor que leva mais tempo para evaporar da pele. Combinar isso com produtos oleosos não é exatamente uma festa para seus poros. Siga a rota sem óleo ou não comedogênica para afastar as espinhas.

Fique hidratado com bons produtos limpos / orgânicos. Uma rotina de hidratação fiel pode fazer muitas coisas benéficas para a sua pele. Sua pele é uma barreira que o protege de fatores ambientais como poluição, bactérias e perda de umidade, e mantê-la hidratada ajuda a manter essa barreira funcionando corretamente. A pele seca é uma pele infeliz e propensa a danos, portanto, aplique um hidratante leve para protegê-la dos agentes secantes do verão, como queimaduras solares, sal e cloro.

Esfolie na hora certa - e não exagere! Não só vai ajudá-lo a manter um bronzeado falso fresco (quando as células mortas da pele descamam, o bronzeado antigo vai sair com ele), mas a esfoliação facial suave ajudará a manter sua pele livre de poros entupidos e criar uma tela melhor para maquiagem aplicativo. No entanto, lembre-se de que a esfoliação revela uma pele nova e sensível que pode ser mais propensa a queimar com o sol. Reserve seus hábitos esfoliantes para a noite (e não para uma ocasião especial) ou para os dias em que não estiver indo direto do chuveiro para a piscina.

Aloe pode ser seu novo melhor amigo durante o verão. É um conhecido antiinflamatório que também proporciona alívio hidratante. Aplicar produtos que contenham aloe vera após a exposição ao sol acalmará e suavizará sua pele, reduzindo a probabilidade de sentir aquela secura horrível e escamosa que vem com o verão. Também é dito que contém antioxidantes que podem ajudar a reparar a pele danificada e evitar que os radicais livres façam seu trabalho indesejável. Mantenha uma planta de babosa em seu quintal ou até mesmo em sua cozinha e use quando precisar!

Invista em hidratantes que atuam na pele úmida quando são mais bem absorvidos. Não pule a reidratação após o banho! Muitas marcas agora fazem sabonetes que fornecem hidratação por meio de seus ingredientes de óleo, com muitos que você aplica antes mesmo de se secar com a toalha.

Compre filtros solares de qualidade. Olhe além do FPS e compre filtros solares de qualidade com ingredientes seguros. Reaplique a cada hora mais ou menos e, se você der um mergulho na água, reaplique quando sair. A água atrai o sol (como a neve), criando um brilho que pode causar queimaduras solares.",
                        Author = "Sandra Pereira",
                        ImageUrl = ConstantesGlobais.Imagens.DicasBelezaVerao,
                    },
                    new NoticiasBlog // Id = 2
                    {
                        Title = "Quantas vezes devo mudar minha maquiagem?",
                        Content = @"Para manter aquele brilho facial saudável, aqui estão alguns fatos úteis sobre a vida útil de seus produtos cosméticos.

O rímel deve ser trocado a cada três meses, pois sua consistência líquida e a exposição ao ar sempre que é aberto o tornam mais vulnerável às bactérias. Sua proximidade com a área dos olhos pode levar a possíveis infecções. Se você acabar com conjuntivite, comumente chamada de 'olho rosa' ou qualquer outra infecção ocular, é melhor jogar o rímel fora imediatamente! Além disso, seja cauteloso ao compartilhar seu rímel com outras pessoas; não é recomendado.

Os delineadores líquidos apresentam as mesmas preocupações das máscaras, por isso devem ser trocados a cada seis meses. Os delineadores de lápis, no entanto, podem durar até dois anos. Afie seu lápis a cada uso para mantê-lo fresco e fácil de usar / aplicar. Limpar regularmente o apontador com uma escova de dentes descartada também é uma boa ideia.

A maioria das fundações deve durar até um ano; no entanto, você deve jogar fora as bases líquidas se notar qualquer mudança no cheiro, textura ou cor.Se você tem tendência a acne, considere substituir sua base a cada seis meses e certifique-se de lavar as mãos, esponjas e escovas com muito mais frequência.

Por causa da consistência líquida do brilho labial, ele precisará ser substituído com mais frequência do que um batom real; a cada 12 meses é recomendado.A longevidade dos corretivos depende da consistência.O corretivo líquido deve ser descartado após um ano; no entanto, o corretivo em pó pode durar até dois anos. Os batons não líquidos também podem durar até dois anos.

Se você notar uma mudança na cor do esmalte ou até mesmo um cheiro ruim, é hora de jogá - lo fora.Normalmente, deve durar até dois anos.Algumas marcas têm datas de validade no verso da garrafa. Ao fazer uma compra, verifique as datas de validade antes de sua compra para ter certeza de que não é um inventário antigo!Se seus produtos não tiverem datas de validade, use um estilete para anotar a data de compra como um guia de frescor.

O pó, o blush, o bronzeador ou a sombra podem durar dois anos, com os devidos cuidados. E não se esqueça de limpar seus pincéis com frequência!

O calor destrói a vida útil de seus produtos favoritos, então um truque do comércio para os moradores do deserto é encontrar uma pequena bolsa de maquiagem e refrigerar sua maquiagem.O bônus da refrigeração é o frescor refrescante durante a aplicação! ",
                        Author = "Adriana Silva",
                        ImageUrl = ConstantesGlobais.Imagens.Maquiagem,
                    },
                };

            // Precisa deles em uma ordem específica
            foreach (var blogPost in blogPosts)
            {
                await dbContext.AddAsync(blogPost);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
