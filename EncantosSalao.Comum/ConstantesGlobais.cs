﻿namespace EncantosSalao.Comum
{
    public static class ConstantesGlobais
    {
        public const string NomeSistema = "EncantosSalao";

        public const string NomePapelAdministrador = "Administrador";

        public const string NomePapelGerenteSalao = "Gerente";

        public const string NomeNuvem = "encantos-salao";

        public static class SemeandoContas
        {
            public const string Senha = "123456";

            public const string EmailAdmin = "admin@encantossalao.com";

            public const string EmailGerenteSalao = "gerente@encantossalao.com";

            public const string EmailUsuario = "usuario@encantossalao.com";
        }

        public static class ValidadoresDados
        {
            public const int TamanhoMaximoTitulo = 60;

            public const int TamanhoMinimoTitulo = 5;

            public const int TamanhoMaximoConteudo = 3500;

            public const int TamanhoMinimoConteudo = 700;

            public const int TamanhoMaximoNome = 40;

            public const int TamanhoMinimoNome = 2;

            public const int TamanhoMaximoDescricao = 700;

            public const int TamanhoMinimoDescricao = 50;

            public const int TamanhoMaximoEndereco = 100;

            public const int TamanhoMinimoEndereco = 5;
        }

        public static class MensagensErro
        {
            public const string Titulo = "Titulo deve estar entre 5 e 60 caracteres.";

            public const string Conteudo = "Conteudo deve estar entre 700 e 3500 caracteres.";

            public const string Autor = "Nome do autor deve estar entre 2 e 40 caracteres.";

            public const string Nome = "Nome deve  estar entre 2 e 40 caracteres.";

            public const string Descricao = "Descrição deve estar entre 50 e 700 caracteres.";

            public const string Endereco = "Endereço deve estar entre 5 e 100 caracteres.";

            public const string Imagem = "Por favor selecione uma imagem JPG, JPEG ou PNG  menor que 1MB.";

            public const string DataHora = "Por favor selecione uma data e hora validas a partir do calendário à esquerda.";

            public const string Avaliacao = "Por favor escolha um número válido que inicia a partir de 1 até 5.";
        }

        public static class FormatosDataHora
        {
            public const string FormatoData = "dd-MM-yyyy";

            public const string FormatoHora = "h:mmtt";

            public const string FormatoDataHora = "dd-MM-yyyy h:mmtt";
        }

        public static class Imagens
        {
            public const string Indice = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/indice.jpg";

            public const string ImagemFundo = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/imagemfundo.jpg";

            public const string Rodape = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/rodape.jpg";

            public const string Erro404 = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/erro404.jpg";


            // NoticiasBlog
            public const string CabeloSaudavelVerao = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/cabelosaudavelverao.jpg";

            public const string Maquiagem = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/maquiagem.jpg";

            public const string DicasBelezaVerao = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/dicasbelezaverao.jpg";

            public const string PeleEstressada = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/peleestressada.jpg";

            // Categorias
            public const string Cabelo = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/cabelo.jpg";

            public const string Depilacao = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/depilacao.jpg";

            public const string Massagem = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/massagem.jpg";

            public const string Unhas = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/unhas.jpg";

            public const string Rosto = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/rosto.jpg";

            public const string Corpo = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/corpo.png";
            
            public const string Maquiador = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/maquiador.png";

            public const string Coloracao = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/coloracao.png";



            // Saloes
            public const string EncantosSalao = "https://encantossalaoweb20211112204048.azurewebsites.net/imagem/encantossalao.jpg";

        }

        public static class ContadoresDadosSemeados
        {
            public const int NoticiaBlog = 4;

            public const int Categorias = 6;

            public const int Servicos = 55;

            public const int Cidades = 2;

            public const int Saloes = 1;

            public const int Agendamentos = 54;
        }
    }
}
