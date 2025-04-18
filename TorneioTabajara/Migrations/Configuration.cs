namespace TorneioTabajara.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TorneioTabajara.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TorneioTabajara.Data.TorneioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TorneioTabajara.Data.TorneioContext context)
        {
            //adionando dados iniciais para a tabela de times
            context.Times.AddOrUpdate(t => t.Nome,
                new Time { Nome = "Flamengo 2019", Cidade = "Rio de Janeiro", Estado = "RJ", AnoFundacao = 1895, Estadio = "Maracanã", CapacidadeEstadio = 78838, CorPrimaria = "Vermelho", CorSecundaria = "Preto", Status = true },
                new Time { Nome = "Palmeiras 2023", Cidade = "São Paulo", Estado = "SP", AnoFundacao = 1914, Estadio = "Allianz Parque", CapacidadeEstadio = 43713, CorPrimaria = "Verde", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "Corinthians 2012", Cidade = "São Paulo", Estado = "SP", AnoFundacao = 1910, Estadio = "Neo Química Arena", CapacidadeEstadio = 49205, CorPrimaria = "Preto", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "São Paulo 2005", Cidade = "São Paulo", Estado = "SP", AnoFundacao = 1930, Estadio = "Morumbi", CapacidadeEstadio = 66000, CorPrimaria = "Branco", CorSecundaria = "Vermelho", Status = true },
                new Time { Nome = "Santos 2011", Cidade = "Santos", Estado = "SP", AnoFundacao = 1912, Estadio = "Vila Belmiro", CapacidadeEstadio = 16068, CorPrimaria = "Branco", CorSecundaria = "Preto", Status = true },
                new Time { Nome = "Grêmio 2017", Cidade = "Porto Alegre", Estado = "RS", AnoFundacao = 1903, Estadio = "Arena do Grêmio", CapacidadeEstadio = 60540, CorPrimaria = "Azul", CorSecundaria = "Preto", Status = true },
                new Time { Nome = "Internacional 2006", Cidade = "Porto Alegre", Estado = "RS", AnoFundacao = 1909, Estadio = "Beira-Rio", CapacidadeEstadio = 50000, CorPrimaria = "Vermelho", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "Atlético Mineiro 2021", Cidade = "Belo Horizonte", Estado = "MG", AnoFundacao = 1908, Estadio = "Arena MRV", CapacidadeEstadio = 46000, CorPrimaria = "Preto", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "Cruzeiro 2003", Cidade = "Belo Horizonte", Estado = "MG", AnoFundacao = 1921, Estadio = "Mineirão", CapacidadeEstadio = 62000, CorPrimaria = "Azul", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "Botafogo 2023", Cidade = "Rio de Janeiro", Estado = "RJ", AnoFundacao = 1904, Estadio = "Nilton Santos", CapacidadeEstadio = 46931, CorPrimaria = "Preto", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "Vasco 2000", Cidade = "Rio de Janeiro", Estado = "RJ", AnoFundacao = 1898, Estadio = "São Januário", CapacidadeEstadio = 21880, CorPrimaria = "Preto", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "Fluminense 2012", Cidade = "Rio de Janeiro", Estado = "RJ", AnoFundacao = 1902, Estadio = "Maracanã", CapacidadeEstadio = 78838, CorPrimaria = "Grená", CorSecundaria = "Verde", Status = true },
                new Time { Nome = "Athletico Paranaense 2019", Cidade = "Curitiba", Estado = "PR", AnoFundacao = 1924, Estadio = "Arena da Baixada", CapacidadeEstadio = 42372, CorPrimaria = "Vermelho", CorSecundaria = "Preto", Status = true },
                new Time { Nome = "Coritiba 1985", Cidade = "Curitiba", Estado = "PR", AnoFundacao = 1909, Estadio = "Couto Pereira", CapacidadeEstadio = 40502, CorPrimaria = "Verde", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "Bahia 1988", Cidade = "Salvador", Estado = "BA", AnoFundacao = 1931, Estadio = "Fonte Nova", CapacidadeEstadio = 50025, CorPrimaria = "Azul", CorSecundaria = "Vermelho", Status = true },
                new Time { Nome = "Sport 2008", Cidade = "Recife", Estado = "PE", AnoFundacao = 1905, Estadio = "Ilha do Retiro", CapacidadeEstadio = 32000, CorPrimaria = "Vermelho", CorSecundaria = "Preto", Status = true },
                new Time { Nome = "Ceará 2020", Cidade = "Fortaleza", Estado = "CE", AnoFundacao = 1914, Estadio = "Castelão", CapacidadeEstadio = 63803, CorPrimaria = "Preto", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "Fortaleza 2021", Cidade = "Fortaleza", Estado = "CE", AnoFundacao = 1918, Estadio = "Castelão", CapacidadeEstadio = 63803, CorPrimaria = "Azul", CorSecundaria = "Vermelho", Status = true },
                new Time { Nome = "Goiás 2005", Cidade = "Goiânia", Estado = "GO", AnoFundacao = 1943, Estadio = "Serrinha", CapacidadeEstadio = 14000, CorPrimaria = "Verde", CorSecundaria = "Branco", Status = true },
                new Time { Nome = "Chapecoense 2016", Cidade = "Chapecó", Estado = "SC", AnoFundacao = 1973, Estadio = "Arena Condá", CapacidadeEstadio = 22000, CorPrimaria = "Verde", CorSecundaria = "Branco", Status = true }
            );
            //adicionando dados iniciais para a tabela dos jogadores (função para os jogadores do flamento)
            var flamengo = context.Times.FirstOrDefault(t => t.Nome == "Flamengo 2019");

            if (flamengo != null && !context.Jogadores.Any(j => j.TimeId == flamengo.Id))
            {
                var jogadores = new List<Jogador>
                {
                    new Jogador { Nome = "Diego Alves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 6, 24), Camisa = 1, Altura = 1.88, Peso = 83, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "César", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 1, 27), Camisa = 37, Altura = 1.94, Peso = 88, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Gabriel Batista", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 6, 3), Camisa = 22, Altura = 1.88, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Rafinha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 9, 7), Camisa = 13, Altura = 1.72, Peso = 68, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Rodinei", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 1, 29), Camisa = 2, Altura = 1.77, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Filipe Luís", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 8, 9), Camisa = 16, Altura = 1.82, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = flamengo.Id },
                    new Jogador { Nome = "Renê", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 9, 14), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = flamengo.Id },
                    new Jogador { Nome = "Rodrigo Caio", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 8, 17), Camisa = 3, Altura = 1.82, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Pablo Marí", Nacionalidade = "Espanhol", DataNascimento = new DateTime(1993, 8, 31), Camisa = 24, Altura = 1.93, Peso = 87, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = flamengo.Id },
                    new Jogador { Nome = "Thuler", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 3, 10), Camisa = 26, Altura = 1.86, Peso = 83, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Rhodolfo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 9, 11), Camisa = 44, Altura = 1.93, Peso = 84, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },

                    new Jogador { Nome = "Willian Arão", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 3, 12), Camisa = 5, Altura = 1.81, Peso = 78, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Gerson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 5, 20), Camisa = 15, Altura = 1.84, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Esquerdo, TimeId = flamengo.Id },
                    new Jogador { Nome = "Diego Ribas", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 2, 28), Camisa = 10, Altura = 1.75, Peso = 76, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Éverton Ribeiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 4, 10), Camisa = 7, Altura = 1.74, Peso = 72, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = flamengo.Id },
                    new Jogador { Nome = "Arrascaeta", Nacionalidade = "Uruguaio", DataNascimento = new DateTime(1994, 6, 1), Camisa = 14, Altura = 1.76, Peso = 69, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = flamengo.Id },
                    new Jogador { Nome = "Reinier", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 19), Camisa = 19, Altura = 1.85, Peso = 78, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Gabigol", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 8, 30), Camisa = 9, Altura = 1.78, Peso = 73, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = flamengo.Id },
                    new Jogador { Nome = "Bruno Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 12, 30), Camisa = 27, Altura = 1.84, Peso = 74, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Vitinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 10, 9), Camisa = 11, Altura = 1.80, Peso = 72, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Lincoln", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 12, 16), Camisa = 29, Altura = 1.82, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = flamengo.Id },

                    new Jogador { Nome = "Berrío", Nacionalidade = "Colombiano", DataNascimento = new DateTime(1991, 1, 14), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Orlando Berrío", Nacionalidade = "Colombiano", DataNascimento = new DateTime(1991, 2, 14), Camisa = 28, Altura = 1.85, Peso = 79, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "João Lucas", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 3, 9), Camisa = 32, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Matheus Dantas", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 9, 5), Camisa = 43, Altura = 1.85, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Hugo Moura", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 3, 3), Camisa = 35, Altura = 1.78, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Vinicius Souza", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 6, 17), Camisa = 16, Altura = 1.83, Peso = 79, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Lucas Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 2, 28), Camisa = 36, Altura = 1.78, Peso = 70, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Rafael Santos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 2, 2), Camisa = 40, Altura = 1.88, Peso = 82, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Léo Pereira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 5, 24), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id },
                    new Jogador { Nome = "Natan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 1, 1), Camisa = 34, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = flamengo.Id }
                };

                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (flamengo != null && !context.Comissaos.Any(j => j.TimeId == flamengo.Id))
            {
                var comissao = new List<Comissao>
                {
                    new Comissao { Nome = "Jorge Jesus", DataNascimento = new DateTime(1954, 7, 24), Cargo = Cargo.Treinador, TimeId = flamengo.Id },
                    new Comissao { Nome = "João de Deus", DataNascimento = new DateTime(1967, 1, 15), Cargo = Cargo.Auxiliar, TimeId = flamengo.Id },
                    new Comissao { Nome = "Carlos Costa", DataNascimento = new DateTime(1975, 9, 5), Cargo = Cargo.PreparadorFisico, TimeId = flamengo.Id },
                    new Comissao { Nome = "Marcio Tannure", DataNascimento = new DateTime(1973, 11, 2), Cargo = Cargo.Fisiologista, TimeId = flamengo.Id },
                    new Comissao { Nome = "Wagner Miranda", DataNascimento = new DateTime(1978, 3, 19), Cargo = Cargo.TreinadorGoleiros, TimeId = flamengo.Id },
                };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var palmeiras = context.Times.FirstOrDefault(t => t.Nome == "Palmeiras 2023");
            if (palmeiras != null && !context.Jogadores.Any(j => j.TimeId == palmeiras.Id))
            {
                var jogadores = new List<Jogador>
                {
                    new Jogador { Nome = "Weverton", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 12, 2), Camisa = 21, Altura = 1.88, Peso = 85, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Marcelo Lomba", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 11, 6), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Vinícius Silvestre", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 22), Camisa = 40, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Marcos Rocha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 10, 9), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Gabriel Menino", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 5, 29), Camisa = 25, Altura = 1.80, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Mayke", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 5, 12), Camisa = 12, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Piqueires", Nacionalidade = "Argentino", DataNascimento = new DateTime(1998, 1, 1), Camisa = 22, Altura = 1.80, Peso = 75, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Matías Viña", Nacionalidade = "Uruguaio", DataNascimento = new DateTime(1997, 11, 9), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Renan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Gustavo Gómez", Nacionalidade = "Paraguaio", DataNascimento = new DateTime(1993, 5, 6), Camisa = 15, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },

                    new Jogador { Nome = "Luan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 5, 1), Camisa = 13, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Murilo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 26, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Kuscevic", Nacionalidade = "Chileno", DataNascimento = new DateTime(1996, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Danilo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Zé Rafael", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 5, 9), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Gabriel Menino", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 5, 29), Camisa = 25, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Raphael Veiga", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 5, 19), Camisa = 23, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Scarpa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 14, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Dudu", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Rony", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Gabriel Veron", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 1), Camisa = 27, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },

                    new Jogador { Nome = "Endrick", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2006, 1, 1), Camisa = 30, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Flaco López", Nacionalidade = "Argentino", DataNascimento = new DateTime(1999, 1, 1), Camisa = 9, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Artur", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Luis Adriano", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Gabriel Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Endrick", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2006, 1, 1), Camisa = 30, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Rafael Elias", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 1, 1), Camisa = 28, Altura = 1.80, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Rafael Santos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 1, 1), Camisa = 40, Altura = 1.80, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Alberto Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 43, Altura = 1.81, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id },
                    new Jogador { Nome = "Roberto Barros", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 69, Altura = 1.80, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = palmeiras.Id }
                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (palmeiras != null && !context.Comissaos.Any(j => j.TimeId == palmeiras.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Abel Ferreira", DataNascimento = new DateTime(1978, 12, 22), Cargo = Cargo.Treinador, TimeId = palmeiras.Id },
        new Comissao { Nome = "Vitor Castanheira", DataNascimento = new DateTime(1979, 5, 3), Cargo = Cargo.Auxiliar, TimeId = palmeiras.Id },
        new Comissao { Nome = "João Martins", DataNascimento = new DateTime(1981, 7, 17), Cargo = Cargo.PreparadorFisico, TimeId = palmeiras.Id },
        new Comissao { Nome = "Carlos Pacheco", DataNascimento = new DateTime(1980, 3, 11), Cargo = Cargo.Fisiologista, TimeId = palmeiras.Id },
        new Comissao { Nome = "Pedro Reis", DataNascimento = new DateTime(1977, 9, 4), Cargo = Cargo.TreinadorGoleiros, TimeId = palmeiras.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var corinthians = context.Times.FirstOrDefault(t => t.Nome == "Corinthians 2012");
            if (corinthians != null && !context.Jogadores.Any(j => j.TimeId == corinthians.Id))
            {
                var jogadores = new List<Jogador>
                {
                    new Jogador { Nome = "Cássio", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 6, 6), Camisa = 80, Altura = 1.90, Peso = 85, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Walter", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 19), Camisa = 27, Altura = 1.88, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Caíque", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Fagner", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 3, 11), Camisa = 82, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Fábio Santos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1980, 5, 15), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = corinthians.Id },
                    new Jogador { Nome = "Guilherme Arana", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 4, 14), Camisa = 84, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = corinthians.Id },
                    new Jogador { Nome = "Danilo Avelar", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 2, 28), Camisa = 81, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = corinthians.Id },
                    new Jogador { Nome = "Gil", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 9, 7), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Pablo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 4, 15), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Ambidestro, TimeId = corinthians.Id },
                    new Jogador { Nome = "Balbuena", Nacionalidade = "Paraguaio", DataNascimento = new DateTime(1991, 5, 23), Camisa = 34, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },

                    new Jogador { Nome = "Bruno Méndez", Nacionalidade = "Uruguaio", DataNascimento = new DateTime(1997, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Gabriel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 5, 17), Camisa = 5, Altura = 1.81, Peso = 78, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Renê Júnior", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Maycon", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 88, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Douglas", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Rodriguinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 26, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Jadson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 1, 1), Camisa = 77, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Romero", Nacionalidade = "Paraguaio", DataNascimento = new DateTime(1993, 1, 1), Camisa = 12, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Ambidestro, TimeId = corinthians.Id },
                    new Jogador { Nome = "Sheik", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1978, 1, 1), Camisa = 13, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Romero", Nacionalidade = "Paraguaio", DataNascimento = new DateTime(1993, 1, 1), Camisa = 14, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },

                    new Jogador { Nome = "Lucca", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 15, Altura = 1.80, Peso = 75, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Gustavo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 16, Altura = 1.80, Peso = 75, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Pedrinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Clayson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 18, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Romero", Nacionalidade = "Paraguaio", DataNascimento = new DateTime(1993, 1, 1), Camisa = 19, Altura = 1.80, Peso = 75, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Kazim", Nacionalidade = "Turco", DataNascimento = new DateTime(1987, 1, 1), Camisa = 20, Altura = 1.80, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = corinthians.Id },
                    new Jogador { Nome = "Guilherme", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 21, Altura = 1.80, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "André", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 22, Altura = 1.80, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },
                    new Jogador { Nome = "Maldonado", Nacionalidade = "Chileno", DataNascimento = new DateTime(1984, 1, 1), Camisa = 23, Altura = 1.80, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Ambidestro, TimeId = corinthians.Id },
                    new Jogador { Nome = "Romero", Nacionalidade = "Paraguaio", DataNascimento = new DateTime(1993, 1, 1), Camisa = 24, Altura = 1.80, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = corinthians.Id },

                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (corinthians != null && !context.Comissaos.Any(j => j.TimeId == corinthians.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Tite Silva", DataNascimento = new DateTime(1961, 5, 25), Cargo = Cargo.Treinador, TimeId = corinthians.Id },
        new Comissao { Nome = "Cleber Xavier", DataNascimento = new DateTime(1963, 8, 29), Cargo = Cargo.Auxiliar, TimeId = corinthians.Id },
        new Comissao { Nome = "Fábio Mahseredjian", DataNascimento = new DateTime(1967, 10, 5), Cargo = Cargo.PreparadorFisico, TimeId = corinthians.Id },
        new Comissao { Nome = "Ricardo Rosa", DataNascimento = new DateTime(1970, 6, 19), Cargo = Cargo.Fisiologista, TimeId = corinthians.Id },
        new Comissao { Nome = "Gilberto Lopes", DataNascimento = new DateTime(1975, 4, 3), Cargo = Cargo.TreinadorGoleiros, TimeId = corinthians.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }
            var saoPaulo = context.Times.FirstOrDefault(t => t.Nome == "São Paulo 2005");
            if (saoPaulo != null && !context.Jogadores.Any(j => j.TimeId == saoPaulo.Id))
            {
                var jogadores = new List<Jogador>
                {
                    new Jogador { Nome = "Felipe Alves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 1, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Jandrei", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Thiago Couto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Igor Vinícius", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Reinaldo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Léo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Bruno Alves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Miranda", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 22, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Léo Pelé", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 13, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Diego Costa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },

                    new Jogador { Nome = "Luan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 10, Altura = 1.85, Peso = 80, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Gabriel Sara", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 21, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Tchê Tchê", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Luan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 10, Altura = 1.85, Peso = 80, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Igor Gomes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 26, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Nestor", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 1, 1), Camisa = 28, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Pato", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Calleri", Nacionalidade = "Argentino", DataNascimento = new DateTime(1993, 1, 1), Camisa = 9, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Luciano", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Eder", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 1, 1), Camisa = 20, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },

                    new Jogador { Nome = "Vitor Bueno", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Trellez", Nacionalidade = "Colombiano", DataNascimento = new DateTime(1990, 1, 1), Camisa = 18, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Helinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 19, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Talles Costa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 1, 1), Camisa = 29, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Igor Gomes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 26, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Nestor", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 1, 1), Camisa = 28, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Pato", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Calleri", Nacionalidade = "Argentino", DataNascimento = new DateTime(1993, 1, 1), Camisa = 9, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Luciano", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },
                    new Jogador { Nome = "Eder", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 1, 1), Camisa = 20, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = saoPaulo.Id },

                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (saoPaulo != null && !context.Comissaos.Any(j => j.TimeId == saoPaulo.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Paulo Autuori", DataNascimento = new DateTime(1956, 8, 25), Cargo = Cargo.Treinador, TimeId = saoPaulo.Id },
        new Comissao { Nome = "Milton Cruz", DataNascimento = new DateTime(1957, 8, 1), Cargo = Cargo.Auxiliar, TimeId = saoPaulo.Id },
        new Comissao { Nome = "Alexandre Costa", DataNascimento = new DateTime(1968, 2, 13), Cargo = Cargo.PreparadorFisico, TimeId = saoPaulo.Id },
        new Comissao { Nome = "Renato Silva", DataNascimento = new DateTime(1972, 12, 15), Cargo = Cargo.Fisiologista, TimeId = saoPaulo.Id },
        new Comissao { Nome = "Marcelo Braga", DataNascimento = new DateTime(1979, 9, 10), Cargo = Cargo.TreinadorGoleiros, TimeId = saoPaulo.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }
            var santos = context.Times.FirstOrDefault(t => t.Nome == "Santos 2011");
            if (santos != null && !context.Jogadores.Any(j => j.TimeId == santos.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Rafael", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 1, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Vanderlei", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 1, 1), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Félix", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Victor Ferraz", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Zeca", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = santos.Id },
                new Jogador { Nome = "Guilherme Santos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "David Braz", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Eduardo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Gustavo Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Lucas Veríssimo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = santos.Id },

                new Jogador { Nome = "Luan Peres", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Alison", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Diego Pituca", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 25, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Lucas Lima", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Jean Mota", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 27, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Rodrygo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Gabriel Barbosa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 9, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Sasha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Bruno Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 19, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Gabriel Pirani", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 1, 1), Camisa = 20, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },

                new Jogador { Nome = "Marinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 31, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Lucas Braga", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 29, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Kaio Jorge", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Felipe Jonatan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 34, Altura = 1.80, Peso = 75, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Sandry", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 1), Camisa = 38, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Lucas Veríssimo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Lucas Braga", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 29, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Kaio Jorge", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Felipe Jonatan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 34, Altura = 1.80, Peso = 75, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = santos.Id },
                new Jogador { Nome = "Sandry", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 1), Camisa = 38, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = santos.Id },


                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (santos != null && !context.Comissaos.Any(j => j.TimeId == santos.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Muricy Ramalho", DataNascimento = new DateTime(1955, 11, 30), Cargo = Cargo.Treinador, TimeId = santos.Id },
        new Comissao { Nome = "Marcelo Fernandes", DataNascimento = new DateTime(1971, 4, 20), Cargo = Cargo.Auxiliar, TimeId = santos.Id },
        new Comissao { Nome = "Renato Oliveira", DataNascimento = new DateTime(1976, 6, 12), Cargo = Cargo.PreparadorFisico, TimeId = santos.Id },
        new Comissao { Nome = "João Silveira", DataNascimento = new DateTime(1978, 1, 5), Cargo = Cargo.Fisiologista, TimeId = santos.Id },
        new Comissao { Nome = "Pedro Gama", DataNascimento = new DateTime(1982, 9, 14), Cargo = Cargo.TreinadorGoleiros, TimeId = santos.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var gremio = context.Times.FirstOrDefault(t => t.Nome == "Grêmio 2017");
            if (gremio != null && !context.Jogadores.Any(j => j.TimeId == gremio.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Marcelo Grohe", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 1, 1), Camisa = 1, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Bruno Grassi", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Paulo Victor", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Edílson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Marcelo Oliveira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = gremio.Id },
                new Jogador { Nome = "Bruno Cortez", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Pedro Geromel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Kahê", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Bressan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Bruno Alves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = gremio.Id },

                new Jogador { Nome = "Maicon", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Walace", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Arthur", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 25, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Ramiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Luan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Fernandinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Edilson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 31, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Everton", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Ramiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Cícero", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 20, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },

                new Jogador { Nome = "Jailson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 31, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Léo Moura", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1978, 1, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Maicon", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Walace", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Arthur", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 25, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Ramiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Luan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Fernandinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Edilson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 31, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },
                new Jogador { Nome = "Everton", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = gremio.Id },

                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (gremio != null && !context.Comissaos.Any(j => j.TimeId == gremio.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Renato Gaúcho", DataNascimento = new DateTime(1962, 9, 9), Cargo = Cargo.Treinador, TimeId = gremio.Id },
        new Comissao { Nome = "Alexandre Mendes", DataNascimento = new DateTime(1975, 2, 5), Cargo = Cargo.Auxiliar, TimeId = gremio.Id },
        new Comissao { Nome = "Luiz Carlos", DataNascimento = new DateTime(1970, 11, 20), Cargo = Cargo.PreparadorFisico, TimeId = gremio.Id },
        new Comissao { Nome = "Carlos Souza", DataNascimento = new DateTime(1973, 5, 14), Cargo = Cargo.Fisiologista, TimeId = gremio.Id },
        new Comissao { Nome = "Fábio Nogueira", DataNascimento = new DateTime(1978, 6, 2), Cargo = Cargo.TreinadorGoleiros, TimeId = gremio.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var internacional = context.Times.FirstOrDefault(t => t.Nome == "Internacional 2006");
            if (internacional != null && !context.Jogadores.Any(j => j.TimeId == internacional.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Vitor", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 1, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Renan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Muriel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Fabiano", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Thiago Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = internacional.Id },
                new Jogador { Nome = "Kleber", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Rodrigo Moledo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Paulão", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Juan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Indio", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = internacional.Id },

                new Jogador { Nome = "Edson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Sandro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Tinga", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 1, 1), Camisa = 25, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "D'Alessandro", Nacionalidade = "Argentino", DataNascimento = new DateTime(1981, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Anderson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Nilmar", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Leandro Damião", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 31, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Eduardo Sasha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Alex", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 1, 1), Camisa = 20, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Wellington Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 29, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },

                new Jogador { Nome = "Valdívia", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 38, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Rodrigo Lindoso", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "D'Alessandro", Nacionalidade = "Argentino", DataNascimento = new DateTime(1981, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Anderson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Nilmar", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Leandro Damião", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 31, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Eduardo Sasha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Alex", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 1, 1), Camisa = 20, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Wellington Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 29, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },
                new Jogador { Nome = "Valdívia", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 38, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = internacional.Id },

                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (internacional != null && !context.Comissaos.Any(j => j.TimeId == internacional.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Abel Braga", DataNascimento = new DateTime(1952, 9, 1), Cargo = Cargo.Treinador, TimeId = internacional.Id },
        new Comissao { Nome = "Leomir Souza", DataNascimento = new DateTime(1960, 1, 15), Cargo = Cargo.Auxiliar, TimeId = internacional.Id },
        new Comissao { Nome = "Rodrigo Pacheco", DataNascimento = new DateTime(1974, 4, 7), Cargo = Cargo.PreparadorFisico, TimeId = internacional.Id },
        new Comissao { Nome = "Marcos Lima", DataNascimento = new DateTime(1971, 3, 27), Cargo = Cargo.Fisiologista, TimeId = internacional.Id },
        new Comissao { Nome = "Henrique Duarte", DataNascimento = new DateTime(1980, 2, 8), Cargo = Cargo.TreinadorGoleiros, TimeId = internacional.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var atletico = context.Times.FirstOrDefault(t => t.Nome == "Atlético Mineiro 2021");
            if (atletico != null && !context.Jogadores.Any(j => j.TimeId == atletico.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Everson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 22, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Rafael", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Victor", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 1, 1), Camisa = 1, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Guga", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Guilherme Arana", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = atletico.Id },
                new Jogador { Nome = "Mariano", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Junior Alonso", Nacionalidade = "Paraguaio", DataNascimento = new DateTime(1993, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Igor Rabello", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Nathan Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Réver", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },

                new Jogador { Nome = "Júnior", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Allan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Hulk", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Nacho Fernández", Nacionalidade = "Argentino", DataNascimento = new DateTime(1990, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Tardelli", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Eduardo Vargas", Nacionalidade = "Chileno", DataNascimento = new DateTime(1990, 1, 1), Camisa = 31, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Keno", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Savinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2004, 1, 1), Camisa = 29, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Mariano", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Junior Alonso", Nacionalidade = "Paraguaio", DataNascimento = new DateTime(1993, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },

                new Jogador { Nome = "Igor Rabello", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Nathan Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Réver", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Júnior", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Allan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Hulk", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Nacho Fernández", Nacionalidade = "Argentino", DataNascimento = new DateTime(1990, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Tardelli", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Eduardo Vargas", Nacionalidade = "Chileno", DataNascimento = new DateTime(1990, 1, 1), Camisa = 31, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },
                new Jogador { Nome = "Keno", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 29, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = atletico.Id },


                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (atletico != null && !context.Comissaos.Any(j => j.TimeId == atletico.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Cuca", DataNascimento = new DateTime(1963, 6, 7), Cargo = Cargo.Treinador, TimeId = atletico.Id },
        new Comissao { Nome = "Cuquinha", DataNascimento = new DateTime(1967, 8, 12), Cargo = Cargo.Auxiliar, TimeId = atletico.Id },
        new Comissao { Nome = "Gustavo Lopes", DataNascimento = new DateTime(1976, 1, 29), Cargo = Cargo.PreparadorFisico, TimeId = atletico.Id },
        new Comissao { Nome = "Ricardo Pereira", DataNascimento = new DateTime(1974, 11, 23), Cargo = Cargo.Fisiologista, TimeId = atletico.Id },
        new Comissao { Nome = "Danilo Campos", DataNascimento = new DateTime(1981, 10, 3), Cargo = Cargo.TreinadorGoleiros, TimeId = atletico.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var cruzeiro = context.Times.FirstOrDefault(t => t.Nome == "Cruzeiro 2003");
            if (cruzeiro != null && !context.Jogadores.Any(j => j.TimeId == cruzeiro.Id))
            {
                var jogadores = new List<Jogador> {
new Jogador { Nome = "Fábio", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 1, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Rafael", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Diego Cavalieri", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Mayke", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 1, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Egídio", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = cruzeiro.Id },
new Jogador { Nome = "Fabrício", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 13, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Thiago Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 14, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = cruzeiro.Id },
new Jogador { Nome = "Dedé", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Léo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Bruno Viana", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Léo Santos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Ramon", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Manoel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 15, Altura = 1.83, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Lucas Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 16, Altura = 1.82, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Ariel Cabral", Nacionalidade = "Argentino", DataNascimento = new DateTime(1987, 1, 1), Camisa = 18, Altura = 1.85, Peso = 77, Posicao = Posicao.Volante, PePreferido = PePreferido.Esquerdo, TimeId = cruzeiro.Id },
new Jogador { Nome = "Thiago Neves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Giorgian De Arrascaeta", Nacionalidade = "Uruguaio", DataNascimento = new DateTime(1994, 1, 1), Camisa = 14, Altura = 1.76, Peso = 70, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Robinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Fred", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 1, 1), Camisa = 9, Altura = 1.85, Peso = 78, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Thiago Ribeiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Rafael Sobis", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 17, Altura = 1.78, Peso = 74, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Sassá", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 99, Altura = 1.83, Peso = 79, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "David", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 1, 1), Camisa = 22, Altura = 1.79, Peso = 74, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = cruzeiro.Id },
new Jogador { Nome = "Raniel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 21, Altura = 1.82, Peso = 76, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Rafinha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 29, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Bruno Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 20, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Judivan", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 1, 1), Camisa = 27, Altura = 1.81, Peso = 77, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id },
new Jogador { Nome = "Nonoca", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 19, Altura = 1.75, Peso = 72, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = cruzeiro.Id }


                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
        
            if(cruzeiro != null && !context.Comissaos.Any(j => j.TimeId == cruzeiro.Id))
{
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Vanderlei Luxemburgo", DataNascimento = new DateTime(1952, 5, 10), Cargo = Cargo.Treinador, TimeId = cruzeiro.Id },
        new Comissao { Nome = "José Ricardo", DataNascimento = new DateTime(1959, 2, 11), Cargo = Cargo.Auxiliar, TimeId = cruzeiro.Id },
        new Comissao { Nome = "Leonardo Souza", DataNascimento = new DateTime(1973, 7, 18), Cargo = Cargo.PreparadorFisico, TimeId = cruzeiro.Id },
        new Comissao { Nome = "Marcos Vinícius", DataNascimento = new DateTime(1972, 9, 25), Cargo = Cargo.Fisiologista, TimeId = cruzeiro.Id },
        new Comissao { Nome = "Diego Tavares", DataNascimento = new DateTime(1980, 8, 14), Cargo = Cargo.TreinadorGoleiros, TimeId = cruzeiro.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var botafogo = context.Times.FirstOrDefault(t => t.Nome == "Botafogo 2023");
            if (botafogo != null && !context.Jogadores.Any(j => j.TimeId == botafogo.Id))
            {
                var jogadores = new List<Jogador> {
               new Jogador { Nome = "Lucas Perri", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 1, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Diego Loureiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "César", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Marcelo Benevenuto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Daniel Borges", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = botafogo.Id },
new Jogador { Nome = "Marçal", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Kanu", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Carli", Nacionalidade = "Argentino", DataNascimento = new DateTime(1987, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Cuesta", Nacionalidade = "Argentino", DataNascimento = new DateTime(1988, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Marcelo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Victor Sá", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Lucas Fernandes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Lucas Piazon", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Tiquinho Soares", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Erison", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 9, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Luis Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Matheus Nascimento", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2003, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Hugo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 4, 5), Camisa = 22, Altura = 1.82, Peso = 76, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = botafogo.Id },
new Jogador { Nome = "Rafael", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 7, 9), Camisa = 20, Altura = 1.76, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Patrick de Paula", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 9, 8), Camisa = 18, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Tchê Tchê", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 8, 30), Camisa = 6, Altura = 1.73, Peso = 70, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Kayque", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 10, 10), Camisa = 15, Altura = 1.78, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Jacob Montes", Nacionalidade = "Estadunidense", DataNascimento = new DateTime(1998, 10, 20), Camisa = 14, Altura = 1.80, Peso = 72, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Jeffinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 12, 30), Camisa = 21, Altura = 1.76, Peso = 70, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = botafogo.Id },
new Jogador { Nome = "Matheus Frizzo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 7, 24), Camisa = 27, Altura = 1.82, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Júnior Santos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 10, 11), Camisa = 19, Altura = 1.84, Peso = 77, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Danilo Barbosa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 2, 28), Camisa = 16, Altura = 1.83, Peso = 74, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Gabriel Pires", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 9, 18), Camisa = 23, Altura = 1.83, Peso = 77, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = botafogo.Id },
new Jogador { Nome = "João Victor", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 5, 14), Camisa = 26, Altura = 1.79, Peso = 74, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },
new Jogador { Nome = "Philipe Sampaio", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 11, 11), Camisa = 13, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = botafogo.Id },



                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (botafogo != null && !context.Comissaos.Any(j => j.TimeId == botafogo.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Luís Castro", DataNascimento = new DateTime(1961, 9, 3), Cargo = Cargo.Treinador, TimeId = botafogo.Id },
        new Comissao { Nome = "Bruno Lage", DataNascimento = new DateTime(1976, 5, 12), Cargo = Cargo.Auxiliar, TimeId = botafogo.Id },
        new Comissao { Nome = "Renato Ribeiro", DataNascimento = new DateTime(1980, 2, 27), Cargo = Cargo.PreparadorFisico, TimeId = botafogo.Id },
        new Comissao { Nome = "André Bastos", DataNascimento = new DateTime(1979, 4, 5), Cargo = Cargo.Fisiologista, TimeId = botafogo.Id },
        new Comissao { Nome = "Felipe Lopes", DataNascimento = new DateTime(1982, 11, 14), Cargo = Cargo.TreinadorGoleiros, TimeId = botafogo.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var vasco = context.Times.FirstOrDefault(t => t.Nome == "Vasco 2000");
            if (vasco != null && !context.Jogadores.Any(j => j.TimeId == vasco.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Helton Leite", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 1, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Fernando Miguel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Sidão", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Yago Pikachu", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 1, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = vasco.Id },
new Jogador { Nome = "Danilo Barcelos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Leandro Castán", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Ricardo Graça", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Miranda", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Anderson Martins", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Zeca", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 13, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "André", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Marcos Júnior", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Gabriel Pec", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 1, 1), Camisa = 7, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Talles Magno", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 1), Camisa = 9, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Bruno Gomes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Germán Cano", Nacionalidade = "Argentino", DataNascimento = new DateTime(1988, 1, 1), Camisa = 17, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Rildo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 15, Altura = 1.77, Peso = 72, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = vasco.Id },
new Jogador { Nome = "Caio Lopes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 1, 1), Camisa = 14, Altura = 1.74, Peso = 70, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Lucas Santos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 16, Altura = 1.72, Peso = 69, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = vasco.Id },
new Jogador { Nome = "Ernando", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 18, Altura = 1.85, Peso = 79, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Léo Matos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 19, Altura = 1.82, Peso = 78, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "MT", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 1, 1), Camisa = 20, Altura = 1.78, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Vinícius", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 1, 1), Camisa = 21, Altura = 1.76, Peso = 70, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = vasco.Id },
new Jogador { Nome = "Cayo Tenório", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 1), Camisa = 22, Altura = 1.80, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Juninho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 1, 1), Camisa = 23, Altura = 1.78, Peso = 73, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Carlinhos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 1, 1), Camisa = 24, Altura = 1.75, Peso = 70, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = vasco.Id },
new Jogador { Nome = "Arthur Sales", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2002, 1, 1), Camisa = 26, Altura = 1.77, Peso = 71, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Andrey", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 27, Altura = 1.83, Peso = 79, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = vasco.Id },
new Jogador { Nome = "Michel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 29, Altura = 1.81, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = vasco.Id },



                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (vasco != null && !context.Comissaos.Any(j => j.TimeId == vasco.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Antonio Lopes", DataNascimento = new DateTime(1941, 6, 12), Cargo = Cargo.Treinador, TimeId = vasco.Id },
        new Comissao { Nome = "Henrique Silva", DataNascimento = new DateTime(1969, 8, 8), Cargo = Cargo.Auxiliar, TimeId = vasco.Id },
        new Comissao { Nome = "Márcio Souza", DataNascimento = new DateTime(1973, 10, 19), Cargo = Cargo.PreparadorFisico, TimeId = vasco.Id },
        new Comissao { Nome = "Carlos Mendes", DataNascimento = new DateTime(1980, 1, 24), Cargo = Cargo.Fisiologista, TimeId = vasco.Id },
        new Comissao { Nome = "João Martins", DataNascimento = new DateTime(1985, 6, 9), Cargo = Cargo.TreinadorGoleiros, TimeId = vasco.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var fluminense = context.Times.FirstOrDefault(t => t.Nome == "Fluminense 2012");
            if (fluminense != null && !context.Jogadores.Any(j => j.TimeId == fluminense.Id))
            {
                var jogadores = new List<Jogador> {
                    new Jogador { Nome = "Diego Cavalieri", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 1, 1), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Marcelo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 1, 1), Camisa = 6, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = fluminense.Id },
                    new Jogador { Nome = "Gum", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Leandro Euzébio", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Thiago Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Carlinhos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 1), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Edinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 28, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Diguinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Jean", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 8, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Wellington Nem", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
       
                    new Jogador { Nome = "Fred", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 1, 1), Camisa = 9, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Rafael Sobis", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Thiago Neves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 1, 1), Camisa = 10, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Lucas Andrade", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 4, 12), Camisa = 1, Altura = 1.88, Peso = 79, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Renan Souza", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 3, 18), Camisa = 2, Altura = 1.76, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Bruno Reis", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 8, 5), Camisa = 13, Altura = 1.82, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = fluminense.Id },
                    new Jogador { Nome = "Pedro Almeida", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 11, 10), Camisa = 14, Altura = 1.80, Peso = 77, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "João Victor", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 9, 20), Camisa = 15, Altura = 1.83, Peso = 79, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "André Lima", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 5, 8), Camisa = 16, Altura = 1.78, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = fluminense.Id },
                    new Jogador { Nome = "Fernando Rocha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 6, 23), Camisa = 17, Altura = 1.77, Peso = 70, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    
                    new Jogador { Nome = "Ricardo Moreira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 2, 14), Camisa = 18, Altura = 1.84, Peso = 76, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Caio Matheus", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 7, 3), Camisa = 19, Altura = 1.80, Peso = 72, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = fluminense.Id },
                    new Jogador { Nome = "Victor Hugo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 10, 27), Camisa = 20, Altura = 1.81, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Alex Teixeira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 12, 6), Camisa = 21, Altura = 1.79, Peso = 71, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Danilo Borges", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 3, 17), Camisa = 22, Altura = 1.82, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = fluminense.Id },
                    new Jogador { Nome = "Marcos Paulo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 1, 15), Camisa = 23, Altura = 1.77, Peso = 70, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Rodrigo Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 9, 9), Camisa = 24, Altura = 1.84, Peso = 79, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Luciano Ramos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 8, 28), Camisa = 26, Altura = 1.80, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = fluminense.Id },
                    new Jogador { Nome = "Bruno Cardoso", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 7, 12), Camisa = 27, Altura = 1.86, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fluminense.Id },
                    new Jogador { Nome = "Paulo Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 4), Camisa = 29, Altura = 1.82, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = fluminense.Id }
                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (fluminense != null && !context.Comissaos.Any(j => j.TimeId == fluminense.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Abel Braga", DataNascimento = new DateTime(1952, 9, 1), Cargo = Cargo.Treinador, TimeId = fluminense.Id },
        new Comissao { Nome = "Marcelo Oliveira", DataNascimento = new DateTime(1960, 3, 30), Cargo = Cargo.Auxiliar, TimeId = fluminense.Id },
        new Comissao { Nome = "Ricardo Paiva", DataNascimento = new DateTime(1975, 5, 18), Cargo = Cargo.PreparadorFisico, TimeId = fluminense.Id },
        new Comissao { Nome = "Fábio Teixeira", DataNascimento = new DateTime(1981, 11, 7), Cargo = Cargo.Fisiologista, TimeId = fluminense.Id },
        new Comissao { Nome = "Gustavo Ramos", DataNascimento = new DateTime(1978, 2, 26), Cargo = Cargo.TreinadorGoleiros, TimeId = fluminense.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var athletico = context.Times.FirstOrDefault(t => t.Nome == "Athletico Paranaense 2019");
            if (athletico != null && !context.Jogadores.Any(j => j.TimeId == athletico.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Bento", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 1, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Marcinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 2, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Léo Pereira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Thiago Heleno", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 1), Camisa = 4, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Hugo Moura", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 5, Altura = 1.85, Peso = 80, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Reinaldo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 1, 1), Camisa = 6, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Rony", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 7, Altura = 1.85, Peso = 80, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Nikão", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 1, 1), Camisa = 11, Altura = 1.85, Peso = 80, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Renan Lodi", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 1, 1), Camisa = 16, Altura = 1.85, Peso = 80, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Lucho González", Nacionalidade = "Argentino", DataNascimento = new DateTime(1981, 1, 1), Camisa = 29, Altura = 1.85, Peso = 80, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Marco Ruben", Nacionalidade = "Argentino", DataNascimento = new DateTime(1986, 1, 1), Camisa = 9, Altura = 1.85, Peso = 80, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Bruno Guimarães", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 1), Camisa = 38, Altura = 1.85, Peso = 80, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Pablo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 1), Camisa = 17, Altura = 1.85, Peso = 80, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Lucas Dourado", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 6, 10), Camisa = 10, Altura = 1.79, Peso = 74, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Fernando Dias", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 5, 20), Camisa = 12, Altura = 1.83, Peso = 78, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Esquerdo, TimeId = athletico.Id },
    new Jogador { Nome = "Ricardo Lima", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 7, 8), Camisa = 13, Altura = 1.82, Peso = 77, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Danilo Matos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 3, 17), Camisa = 14, Altura = 1.80, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Gabriel Costa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 12, 11), Camisa = 15, Altura = 1.75, Peso = 70, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "José Arthur", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 4, 6), Camisa = 18, Altura = 1.77, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Esquerdo, TimeId = athletico.Id },
    new Jogador { Nome = "Felipe Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 11, 2), Camisa = 19, Altura = 1.81, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Matheus Vinicius", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 10, 22), Camisa = 20, Altura = 1.79, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Henrique Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 8, 1), Camisa = 21, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Vinícius Rocha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 9, 30), Camisa = 22, Altura = 1.78, Peso = 72, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = athletico.Id },
    new Jogador { Nome = "Gustavo Barreto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 6, 4), Camisa = 23, Altura = 1.84, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Douglas Neves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 3, 28), Camisa = 24, Altura = 1.76, Peso = 71, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Caio Fernandes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 1, 13), Camisa = 25, Altura = 1.82, Peso = 77, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Bruno Luiz", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 5, 5), Camisa = 26, Altura = 1.85, Peso = 80, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = athletico.Id },
    new Jogador { Nome = "Alan Ribeiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 7, 29), Camisa = 27, Altura = 1.83, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = athletico.Id },
    new Jogador { Nome = "Édson Gomes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 2, 18), Camisa = 28, Altura = 1.80, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = athletico.Id }
                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (athletico != null && !context.Comissaos.Any(j => j.TimeId == athletico.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Paulo Autuori", DataNascimento = new DateTime(1956, 8, 25), Cargo = Cargo.Treinador, TimeId = athletico.Id },
        new Comissao { Nome = "Eduardo Amarante", DataNascimento = new DateTime(1975, 4, 2), Cargo = Cargo.Auxiliar, TimeId = athletico.Id },
        new Comissao { Nome = "Robson Pereira", DataNascimento = new DateTime(1982, 6, 14), Cargo = Cargo.PreparadorFisico, TimeId = athletico.Id },
        new Comissao { Nome = "Fernando Diniz", DataNascimento = new DateTime(1974, 3, 27), Cargo = Cargo.Fisiologista, TimeId = athletico.Id },
        new Comissao { Nome = "Rogério Costa", DataNascimento = new DateTime(1980, 1, 12), Cargo = Cargo.TreinadorGoleiros, TimeId = athletico.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var coritiba = context.Times.FirstOrDefault(t => t.Nome == "Coritiba 1985");
            if (coritiba != null && !context.Jogadores.Any(j => j.TimeId == coritiba.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Rafael Camargo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1958, 2, 10), Camisa = 1, Altura = 1.83, Peso = 78, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Jorge Santana", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 4, 20), Camisa = 2, Altura = 1.76, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Renato Luz", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1957, 8, 15), Camisa = 3, Altura = 1.82, Peso = 77, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Wilson Andrade", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 1, 5), Camisa = 4, Altura = 1.81, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = coritiba.Id },
        new Jogador { Nome = "Celso Martins", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 7, 30), Camisa = 5, Altura = 1.79, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Luiz Carlos Rocha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1962, 3, 18), Camisa = 6, Altura = 1.75, Peso = 70, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = coritiba.Id },
        new Jogador { Nome = "Rogério Cunha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1956, 9, 9), Camisa = 7, Altura = 1.78, Peso = 72, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Marcos Leite", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 5, 21), Camisa = 8, Altura = 1.76, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Carlos Ribeiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1955, 12, 10), Camisa = 9, Altura = 1.80, Peso = 76, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "João Batista", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1959, 11, 4), Camisa = 10, Altura = 1.77, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = coritiba.Id },
        new Jogador { Nome = "Eduardo Lima", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 6, 2), Camisa = 11, Altura = 1.79, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = coritiba.Id },
        new Jogador { Nome = "Paulo Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1957, 2, 22), Camisa = 12, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Sérgio Andrade", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1963, 3, 12), Camisa = 13, Altura = 1.76, Peso = 71, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = coritiba.Id },
        new Jogador { Nome = "Daniel Neves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 1, 8), Camisa = 14, Altura = 1.80, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Rodrigo Mendes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1962, 4, 11), Camisa = 15, Altura = 1.74, Peso = 69, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = coritiba.Id },
        new Jogador { Nome = "Alfredo Souza", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1956, 10, 27), Camisa = 16, Altura = 1.78, Peso = 72, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Gilberto Cruz", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1958, 6, 5), Camisa = 17, Altura = 1.81, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Jair Monteiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1959, 7, 19), Camisa = 18, Altura = 1.77, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Ronaldo Campos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 11, 23), Camisa = 19, Altura = 1.79, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = coritiba.Id },
        new Jogador { Nome = "Milton Xavier", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1962, 12, 15), Camisa = 20, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Antonio Luiz", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1957, 5, 1), Camisa = 21, Altura = 1.75, Peso = 70, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Cláudio Ramos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1958, 9, 2), Camisa = 22, Altura = 1.83, Peso = 79, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Vicente Rocha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 8, 3), Camisa = 23, Altura = 1.80, Peso = 76, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Juliano Teixeira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1959, 10, 6), Camisa = 24, Altura = 1.79, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = coritiba.Id },
        new Jogador { Nome = "Rafael Cunha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1955, 4, 17), Camisa = 25, Altura = 1.78, Peso = 74, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Walter Farias", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 6, 28), Camisa = 26, Altura = 1.82, Peso = 77, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Ivan Lopes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1962, 11, 14), Camisa = 27, Altura = 1.76, Peso = 72, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Edson Barros", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1956, 5, 20), Camisa = 28, Altura = 1.80, Peso = 74, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = coritiba.Id },
        new Jogador { Nome = "Nelson Souza", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1958, 10, 29), Camisa = 29, Altura = 1.81, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
        new Jogador { Nome = "Aílton Gomes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 9, 25), Camisa = 30, Altura = 1.77, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = coritiba.Id },
                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (coritiba != null && !context.Comissaos.Any(j => j.TimeId == coritiba.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Émerson Ramos", DataNascimento = new DateTime(1965, 2, 20), Cargo = Cargo.Treinador, TimeId = coritiba.Id },
        new Comissao { Nome = "Juliano Mendes", DataNascimento = new DateTime(1974, 5, 11), Cargo = Cargo.Auxiliar, TimeId = coritiba.Id },
        new Comissao { Nome = "Fernando Borges", DataNascimento = new DateTime(1978, 10, 23), Cargo = Cargo.PreparadorFisico, TimeId = coritiba.Id },
        new Comissao { Nome = "Sérgio Nascimento", DataNascimento = new DateTime(1982, 7, 30), Cargo = Cargo.Fisiologista, TimeId = coritiba.Id },
        new Comissao { Nome = "Cléber Lima", DataNascimento = new DateTime(1976, 1, 17), Cargo = Cargo.TreinadorGoleiros, TimeId = coritiba.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var bahia = context.Times.FirstOrDefault(t => t.Nome == "Bahia 1988");
            if (bahia != null && !context.Jogadores.Any(j => j.TimeId == bahia.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Sidney Gama", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 1, 15), Camisa = 1, Altura = 1.82, Peso = 78, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Marquinhos Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1962, 5, 20), Camisa = 2, Altura = 1.75, Peso = 70, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Paulo Fontes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 8, 30), Camisa = 3, Altura = 1.80, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
        new Jogador { Nome = "Edvaldo Monteiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1959, 3, 9), Camisa = 4, Altura = 1.82, Peso = 77, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Geraldo Ribeiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 7, 25), Camisa = 5, Altura = 1.78, Peso = 74, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Jorge Peixoto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1958, 12, 14), Camisa = 6, Altura = 1.74, Peso = 72, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
        new Jogador { Nome = "Roberto Lopes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1963, 2, 10), Camisa = 7, Altura = 1.76, Peso = 71, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Carlos Macedo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1957, 11, 3), Camisa = 8, Altura = 1.77, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Toninho Almeida", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1956, 4, 18), Camisa = 9, Altura = 1.79, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
        new Jogador { Nome = "Ademir Souza", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1959, 9, 1), Camisa = 10, Altura = 1.78, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
        new Jogador { Nome = "Ivanildo Lima", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 6, 5), Camisa = 11, Altura = 1.76, Peso = 70, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Luis Fabiano", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 10, 12), Camisa = 12, Altura = 1.84, Peso = 79, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Arnaldo Cardoso", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1962, 1, 3), Camisa = 13, Altura = 1.75, Peso = 71, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Márcio Neves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 5, 22), Camisa = 14, Altura = 1.77, Peso = 74, Posicao = Posicao.Volante, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
        new Jogador { Nome = "Fernando Tavares", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1963, 7, 14), Camisa = 15, Altura = 1.74, Peso = 70, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Almir Barbosa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1955, 9, 6), Camisa = 16, Altura = 1.78, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
        new Jogador { Nome = "Renato Dantas", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1959, 8, 29), Camisa = 17, Altura = 1.81, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Gilmar Rocha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 10, 23), Camisa = 18, Altura = 1.76, Peso = 72, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
        new Jogador { Nome = "Sandro Matos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1958, 6, 17), Camisa = 19, Altura = 1.79, Peso = 74, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Jeferson Couto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 3, 28), Camisa = 20, Altura = 1.77, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Mário Sérgio", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1959, 11, 19), Camisa = 21, Altura = 1.76, Peso = 70, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "João Ricardo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1962, 12, 9), Camisa = 22, Altura = 1.82, Peso = 78, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Elias Moura", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1963, 9, 5), Camisa = 23, Altura = 1.78, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Daniel Valença", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1957, 7, 1), Camisa = 24, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
        new Jogador { Nome = "Luiz Eduardo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 2, 27), Camisa = 25, Altura = 1.75, Peso = 70, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Vinícius Prado", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1958, 10, 11), Camisa = 26, Altura = 1.81, Peso = 77, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
        new Jogador { Nome = "Eduardo Sabino", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1962, 11, 16), Camisa = 27, Altura = 1.76, Peso = 71, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Ricardo Fonseca", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1960, 8, 4), Camisa = 28, Altura = 1.80, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Valter Ramos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1959, 12, 2), Camisa = 29, Altura = 1.79, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = bahia.Id },
        new Jogador { Nome = "Túlio Borges", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1961, 6, 6), Camisa = 30, Altura = 1.77, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = bahia.Id },
                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (bahia != null && !context.Comissaos.Any(j => j.TimeId == bahia.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Evaristo de Macedo", DataNascimento = new DateTime(1933, 6, 22), Cargo = Cargo.Treinador, TimeId = bahia.Id },
        new Comissao { Nome = "Gilson Paes", DataNascimento = new DateTime(1978, 3, 30), Cargo = Cargo.Auxiliar, TimeId = bahia.Id },
        new Comissao { Nome = "Lucas Tavares", DataNascimento = new DateTime(1985, 1, 20), Cargo = Cargo.PreparadorFisico, TimeId = bahia.Id },
        new Comissao { Nome = "Ricardo Nunes", DataNascimento = new DateTime(1981, 5, 8), Cargo = Cargo.Fisiologista, TimeId = bahia.Id },
        new Comissao { Nome = "Carlos Menezes", DataNascimento = new DateTime(1977, 10, 14), Cargo = Cargo.TreinadorGoleiros, TimeId = bahia.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var sport = context.Times.FirstOrDefault(t => t.Nome == "Sport 2008");
            if (sport != null && !context.Jogadores.Any(j => j.TimeId == sport.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Fabrício Araújo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1976, 3, 22), Camisa = 1, Altura = 1.85, Peso = 82, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Lúcio Neves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 9, 17), Camisa = 2, Altura = 1.78, Peso = 73, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Éder Souza", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1979, 4, 9), Camisa = 3, Altura = 1.84, Peso = 79, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Rogério Mendonça", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1980, 6, 4), Camisa = 4, Altura = 1.82, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Tiago Paiva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1977, 7, 12), Camisa = 5, Altura = 1.80, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "João Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 1, 5), Camisa = 6, Altura = 1.76, Peso = 72, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Marlon Tavares", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 8, 23), Camisa = 7, Altura = 1.77, Peso = 74, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Cláudio Rezende", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1975, 10, 28), Camisa = 8, Altura = 1.78, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Fábio Morais", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1980, 12, 1), Camisa = 9, Altura = 1.83, Peso = 78, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Gilson Maranhão", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 5, 18), Camisa = 10, Altura = 1.79, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Ricardo Lacerda", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 3, 15), Camisa = 11, Altura = 1.80, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Vítor Cardoso", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 11, 6), Camisa = 12, Altura = 1.86, Peso = 83, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Jefferson Araújo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 2, 19), Camisa = 13, Altura = 1.75, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Wesley Dourado", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1978, 9, 2), Camisa = 14, Altura = 1.81, Peso = 77, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Diogo Freitas", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 7, 21), Camisa = 15, Altura = 1.79, Peso = 75, Posicao = Posicao.Volante, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Caio Bastos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 12, 11), Camisa = 16, Altura = 1.76, Peso = 71, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Lucas Peixoto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1980, 10, 4), Camisa = 17, Altura = 1.78, Peso = 73, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Adriano Farias", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1979, 8, 30), Camisa = 18, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Márcio Guedes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 4, 26), Camisa = 19, Altura = 1.77, Peso = 72, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Rafael Torres", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 5, 13), Camisa = 20, Altura = 1.82, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Juliano Ramos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1977, 6, 3), Camisa = 21, Altura = 1.84, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Felipe Maia", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 9, 27), Camisa = 22, Altura = 1.83, Peso = 79, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Henrique Silveira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 7), Camisa = 23, Altura = 1.74, Peso = 71, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Douglas Azevedo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 11, 16), Camisa = 24, Altura = 1.76, Peso = 73, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Bruno Nogueira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1980, 2, 8), Camisa = 25, Altura = 1.80, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Rodrigo Sales", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 6, 24), Camisa = 26, Altura = 1.78, Peso = 72, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Wellington Cruz", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 3, 30), Camisa = 27, Altura = 1.75, Peso = 70, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "André Vilela", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 8, 19), Camisa = 28, Altura = 1.79, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = sport.Id },
        new Jogador { Nome = "Neto Barreto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 4, 25), Camisa = 29, Altura = 1.81, Peso = 76, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = sport.Id },
        new Jogador { Nome = "Samuel Amaral", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1978, 12, 14), Camisa = 30, Altura = 1.83, Peso = 77, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = sport.Id },
                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (sport != null && !context.Comissaos.Any(j => j.TimeId == sport.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Nelsinho Baptista", DataNascimento = new DateTime(1950, 7, 22), Cargo = Cargo.Treinador, TimeId = sport.Id },
        new Comissao { Nome = "Sandro Meira", DataNascimento = new DateTime(1972, 2, 18), Cargo = Cargo.Auxiliar, TimeId = sport.Id },
        new Comissao { Nome = "Leonardo Guimarães", DataNascimento = new DateTime(1980, 6, 10), Cargo = Cargo.PreparadorFisico, TimeId = sport.Id },
        new Comissao { Nome = "Bruno Almeida", DataNascimento = new DateTime(1983, 9, 25), Cargo = Cargo.Fisiologista, TimeId = sport.Id },
        new Comissao { Nome = "Marcelo Cunha", DataNascimento = new DateTime(1976, 4, 3), Cargo = Cargo.TreinadorGoleiros, TimeId = sport.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var ceara = context.Times.FirstOrDefault(t => t.Nome == "Ceará 2020");
            if (ceara != null && !context.Jogadores.Any(j => j.TimeId == ceara.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Marcelo Teles", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 5, 21), Camisa = 1, Altura = 1.87, Peso = 83, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Felipe Rosa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 3, 14), Camisa = 2, Altura = 1.78, Peso = 74, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Caio Moreira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 11, 9), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "André Goulart", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 7, 2), Camisa = 4, Altura = 1.84, Peso = 79, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Vitor Borges", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 9, 26), Camisa = 5, Altura = 1.81, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Luan Nascimento", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 8, 30), Camisa = 6, Altura = 1.76, Peso = 72, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Matheus Cavalcante", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 2, 12), Camisa = 7, Altura = 1.77, Peso = 71, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Fernando Brígido", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 6, 6), Camisa = 8, Altura = 1.78, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Eduardo Falcão", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 10, 15), Camisa = 9, Altura = 1.83, Peso = 78, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Pedro Veloso", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 12, 3), Camisa = 10, Altura = 1.80, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Wesley Pontes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 1, 7), Camisa = 11, Altura = 1.79, Peso = 73, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Lucas França", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 4, 19), Camisa = 12, Altura = 1.85, Peso = 82, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Alan Teixeira", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 6, 13), Camisa = 13, Altura = 1.75, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Rafael Tavares", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 3, 8), Camisa = 14, Altura = 1.83, Peso = 79, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Leonardo Rocha", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 12, 22), Camisa = 15, Altura = 1.82, Peso = 77, Posicao = Posicao.Volante, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Jean Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 5, 28), Camisa = 16, Altura = 1.78, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Henrique Bastos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 7, 3), Camisa = 17, Altura = 1.80, Peso = 74, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Iago Rezende", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 9, 11), Camisa = 18, Altura = 1.77, Peso = 72, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Danilo Costa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 4, 4), Camisa = 19, Altura = 1.76, Peso = 72, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Rodrigo Peixoto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 2, 25), Camisa = 20, Altura = 1.82, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Gabriel Amaral", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 8, 6), Camisa = 21, Altura = 1.83, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Thiago Muniz", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 10, 1), Camisa = 22, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Caíque Lopes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 3, 19), Camisa = 23, Altura = 1.74, Peso = 70, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Willian Damasceno", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1998, 6, 27), Camisa = 24, Altura = 1.79, Peso = 74, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Bruno Figueiredo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 10, 10), Camisa = 25, Altura = 1.81, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Júnior Arantes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 11, 23), Camisa = 26, Altura = 1.78, Peso = 73, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Eduardo Assis", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 1, 30), Camisa = 27, Altura = 1.75, Peso = 71, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Anderson Moura", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 9, 12), Camisa = 28, Altura = 1.84, Peso = 79, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
        new Jogador { Nome = "Diego Monteiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 12, 14), Camisa = 29, Altura = 1.82, Peso = 77, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = ceara.Id },
        new Jogador { Nome = "Renato Dantas", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 8, 17), Camisa = 30, Altura = 1.80, Peso = 76, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = ceara.Id },
                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (ceara != null && !context.Comissaos.Any(j => j.TimeId == ceara.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Guto Ferreira", DataNascimento = new DateTime(1965, 9, 7), Cargo = Cargo.Treinador, TimeId = ceara.Id },
        new Comissao { Nome = "Alex Nogueira", DataNascimento = new DateTime(1974, 11, 16), Cargo = Cargo.Auxiliar, TimeId = ceara.Id },
        new Comissao { Nome = "Felipe Ramos", DataNascimento = new DateTime(1982, 5, 28), Cargo = Cargo.PreparadorFisico, TimeId = ceara.Id },
        new Comissao { Nome = "Sérgio Mendonça", DataNascimento = new DateTime(1980, 8, 19), Cargo = Cargo.Fisiologista, TimeId = ceara.Id },
        new Comissao { Nome = "Cláudio Vieira", DataNascimento = new DateTime(1979, 3, 9), Cargo = Cargo.TreinadorGoleiros, TimeId = ceara.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var fortaleza = context.Times.FirstOrDefault(t => t.Nome == "Fortaleza 2021");
            if (fortaleza != null && !context.Jogadores.Any(j => j.TimeId == fortaleza.Id))
            {
                var jogadores = new List<Jogador> {
                    new Jogador { Nome = "Felipe Alves", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 5, 15), Camisa = 1, Altura = 1.85, Peso = 79, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Marcelo Boeck", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 11, 28), Camisa = 12, Altura = 1.85, Peso = 83, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Max Walef", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 4, 28), Camisa = 23, Altura = 1.86, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },

        new Jogador { Nome = "Tinga", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 9, 1), Camisa = 2, Altura = 1.78, Peso = 75, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Yago Pikachu", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 6, 5), Camisa = 22, Altura = 1.70, Peso = 70, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Bruno Melo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 10, 26), Camisa = 30, Altura = 1.80, Peso = 76, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = fortaleza.Id },
        new Jogador { Nome = "Titi", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1988, 3, 12), Camisa = 4, Altura = 1.84, Peso = 82, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = fortaleza.Id },
        new Jogador { Nome = "Marcelo Benevenuto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 1, 7), Camisa = 5, Altura = 1.83, Peso = 79, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Jackson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 5, 3), Camisa = 25, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },

        new Jogador { Nome = "Éderson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 7, 7), Camisa = 13, Altura = 1.83, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Felipe", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 4, 15), Camisa = 15, Altura = 1.80, Peso = 77, Posicao = Posicao.Volante, PePreferido = PePreferido.Esquerdo, TimeId = fortaleza.Id },
        new Jogador { Nome = "Matheus Jussa", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 3, 22), Camisa = 8, Altura = 1.85, Peso = 80, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Ronald", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 6, 12), Camisa = 14, Altura = 1.76, Peso = 73, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Lucas Lima", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 7, 9), Camisa = 20, Altura = 1.76, Peso = 72, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = fortaleza.Id },
        new Jogador { Nome = "Lucas Crispim", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 6, 19), Camisa = 10, Altura = 1.78, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Angelo Henríquez", Nacionalidade = "Chileno", DataNascimento = new DateTime(1994, 4, 13), Camisa = 19, Altura = 1.78, Peso = 72, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Robson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 5, 30), Camisa = 7, Altura = 1.82, Peso = 76, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "David", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 10, 13), Camisa = 17, Altura = 1.79, Peso = 75, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = fortaleza.Id },
        new Jogador { Nome = "Wellington Paulista", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 4, 22), Camisa = 9, Altura = 1.83, Peso = 82, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Romarinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 8, 12), Camisa = 11, Altura = 1.73, Peso = 70, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },

        // Complementares/fictícios
        new Jogador { Nome = "Caio Vinícius", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 3, 4), Camisa = 28, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Hércules", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2001, 2, 15), Camisa = 27, Altura = 1.78, Peso = 74, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Igor Torres", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(2000, 3, 11), Camisa = 21, Altura = 1.82, Peso = 76, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Isaque", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1997, 4, 22), Camisa = 26, Altura = 1.78, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Edinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 5, 31), Camisa = 29, Altura = 1.69, Peso = 68, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = fortaleza.Id },
        new Jogador { Nome = "Ronald Falcão", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1999, 1, 30), Camisa = 31, Altura = 1.74, Peso = 71, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Matheus Vargas", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 6, 18), Camisa = 18, Altura = 1.78, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id },
        new Jogador { Nome = "Daniel Guedes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 4, 17), Camisa = 32, Altura = 1.75, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = fortaleza.Id }

                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (fortaleza != null && !context.Comissaos.Any(j => j.TimeId == fortaleza.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Juan Pablo Vojvoda", DataNascimento = new DateTime(1975, 1, 22), Cargo = Cargo.Treinador, TimeId = fortaleza.Id },
        new Comissao { Nome = "Diego Sierra", DataNascimento = new DateTime(1978, 6, 13), Cargo = Cargo.Auxiliar, TimeId = fortaleza.Id },
        new Comissao { Nome = "Marcos Silva", DataNascimento = new DateTime(1984, 4, 4), Cargo = Cargo.PreparadorFisico, TimeId = fortaleza.Id },
        new Comissao { Nome = "Rodrigo Paiva", DataNascimento = new DateTime(1982, 12, 7), Cargo = Cargo.Fisiologista, TimeId = fortaleza.Id },
        new Comissao { Nome = "Thiago Gomes", DataNascimento = new DateTime(1981, 10, 21), Cargo = Cargo.TreinadorGoleiros, TimeId = fortaleza.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }

            var goias = context.Times.FirstOrDefault(t => t.Nome == "Goiás 2005");
            if (goias != null && !context.Jogadores.Any(j => j.TimeId == goias.Id))
            {
                var jogadores = new List<Jogador> {
        new Jogador { Nome = "Harlei", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1972, 3, 30), Camisa = 1, Altura = 1.83, Peso = 79, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Pedro Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1979, 5, 5), Camisa = 12, Altura = 1.84, Peso = 81, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Cléber", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 7, 8), Camisa = 23, Altura = 1.86, Peso = 82, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = goias.Id },

        new Jogador { Nome = "Baiano", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1978, 6, 28), Camisa = 2, Altura = 1.76, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Jadilson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1977, 12, 20), Camisa = 6, Altura = 1.72, Peso = 69, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = goias.Id },
        new Jogador { Nome = "Leonardo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1975, 4, 1), Camisa = 3, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Alex Dias", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1972, 5, 26), Camisa = 4, Altura = 1.80, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Rafael Marques", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 9, 21), Camisa = 13, Altura = 1.85, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = goias.Id },

        new Jogador { Nome = "Cléber Gaúcho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1974, 8, 1), Camisa = 5, Altura = 1.79, Peso = 74, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Ramón", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1972, 3, 15), Camisa = 8, Altura = 1.78, Peso = 73, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Fernandão", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1978, 3, 18), Camisa = 10, Altura = 1.90, Peso = 82, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Fabiano", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1980, 6, 6), Camisa = 11, Altura = 1.76, Peso = 72, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = goias.Id },

        new Jogador { Nome = "Souza", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1975, 11, 12), Camisa = 7, Altura = 1.77, Peso = 70, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Araújo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1977, 1, 11), Camisa = 9, Altura = 1.73, Peso = 68, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Dimba", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1973, 4, 30), Camisa = 19, Altura = 1.78, Peso = 74, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Rogério", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1980, 12, 25), Camisa = 17, Altura = 1.74, Peso = 71, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = goias.Id },

        // Jogadores fictícios para completar os 30
        new Jogador { Nome = "Luiz Fernando", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 8, 10), Camisa = 14, Altura = 1.80, Peso = 76, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Thiago Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 2, 12), Camisa = 15, Altura = 1.84, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Marcos Paulo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 5, 7), Camisa = 16, Altura = 1.78, Peso = 74, Posicao = Posicao.LateralEsquerdo, PePreferido = PePreferido.Esquerdo, TimeId = goias.Id },
        new Jogador { Nome = "Diego Tavares", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 10, 3), Camisa = 18, Altura = 1.76, Peso = 73, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "João Marcos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 6, 21), Camisa = 20, Altura = 1.81, Peso = 77, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Alan Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 3, 4), Camisa = 21, Altura = 1.80, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = goias.Id },
        new Jogador { Nome = "Gustavo Henrique", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 11, 2), Camisa = 22, Altura = 1.79, Peso = 76, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Ricardo Lopes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 9, 30), Camisa = 24, Altura = 1.83, Peso = 78, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Carlos Eduardo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 8, 9), Camisa = 25, Altura = 1.76, Peso = 72, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Rodrigo César", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 7, 1), Camisa = 26, Altura = 1.80, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Vinícius Lima", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 18), Camisa = 27, Altura = 1.78, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Eduardo Ramos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 12, 29), Camisa = 28, Altura = 1.81, Peso = 77, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = goias.Id },
        new Jogador { Nome = "Jonathan Silva", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 4, 14), Camisa = 29, Altura = 1.83, Peso = 79, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = goias.Id },
        new Jogador { Nome = "Paulo Roberto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1983, 2, 6), Camisa = 30, Altura = 1.80, Peso = 75, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = goias.Id }
                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (goias != null && !context.Comissaos.Any(j => j.TimeId == goias.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Hélio dos Anjos", DataNascimento = new DateTime(1958, 3, 7), Cargo = Cargo.Treinador, TimeId = goias.Id },
        new Comissao { Nome = "Renato Viana", DataNascimento = new DateTime(1976, 8, 22), Cargo = Cargo.Auxiliar, TimeId = goias.Id },
        new Comissao { Nome = "André Cunha", DataNascimento = new DateTime(1983, 5, 14), Cargo = Cargo.PreparadorFisico, TimeId = goias.Id },
        new Comissao { Nome = "Lucas Prado", DataNascimento = new DateTime(1985, 1, 30), Cargo = Cargo.Fisiologista, TimeId = goias.Id },
        new Comissao { Nome = "Fernando Lopes", DataNascimento = new DateTime(1979, 9, 5), Cargo = Cargo.TreinadorGoleiros, TimeId = goias.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            } 

            var chapecoense = context.Times.FirstOrDefault(t => t.Nome == "Chapecoense 2016");
            if (chapecoense != null && !context.Jogadores.Any(j => j.TimeId == chapecoense.Id))
            {
                var jogadores = new List<Jogador> {
                new Jogador { Nome = "Danilo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 7, 31), Camisa = 1, Altura = 1.86, Peso = 83, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Nivaldo", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1974, 3, 14), Camisa = 12, Altura = 1.82, Peso = 79, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Marcelo Boeck", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 11, 28), Camisa = 21, Altura = 1.85, Peso = 80, Posicao = Posicao.Goleiro, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },

    new Jogador { Nome = "Gimenez", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 6, 18), Camisa = 2, Altura = 1.77, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Cléber Santana", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 6, 27), Camisa = 8, Altura = 1.78, Peso = 74, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Dener", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 6, 21), Camisa = 6, Altura = 1.75, Peso = 70, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
    new Jogador { Nome = "Thiego", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 5, 22), Camisa = 3, Altura = 1.84, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Filipe Machado", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1984, 3, 13), Camisa = 4, Altura = 1.82, Peso = 76, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Bruno Rangel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 12, 11), Camisa = 9, Altura = 1.83, Peso = 79, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
    new Jogador { Nome = "Ananias", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 1, 20), Camisa = 11, Altura = 1.76, Peso = 73, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },

    new Jogador { Nome = "Arthur Maia", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 10, 13), Camisa = 10, Altura = 1.77, Peso = 71, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
    new Jogador { Nome = "Lucas Gomes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1990, 5, 29), Camisa = 7, Altura = 1.74, Peso = 68, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Sérgio Manoel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 9, 8), Camisa = 5, Altura = 1.78, Peso = 72, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Josimar", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 1, 19), Camisa = 13, Altura = 1.81, Peso = 74, Posicao = Posicao.Volante, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
    new Jogador { Nome = "Gil", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1987, 7, 25), Camisa = 14, Altura = 1.79, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Martinuccio", Nacionalidade = "Argentino", DataNascimento = new DateTime(1987, 9, 13), Camisa = 15, Altura = 1.70, Peso = 69, Posicao = Posicao.Atacante, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
    new Jogador { Nome = "Kempes", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1982, 8, 3), Camisa = 16, Altura = 1.86, Peso = 82, Posicao = Posicao.Atacante, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Alan Ruschel", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 8, 23), Camisa = 17, Altura = 1.76, Peso = 72, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
    new Jogador { Nome = "Rafael Lima", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 3, 8), Camisa = 18, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Demerson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 3, 16), Camisa = 19, Altura = 1.83, Peso = 78, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
    new Jogador { Nome = "Gilson", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1986, 5, 4), Camisa = 20, Altura = 1.74, Peso = 70, Posicao = Posicao.LateralDireito, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },

    new Jogador { Nome = "Yann Rolim", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1995, 3, 15), Camisa = 22, Altura = 1.79, Peso = 72, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Tiaguinho", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1994, 3, 4), Camisa = 23, Altura = 1.75, Peso = 70, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Hyoran", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1993, 5, 25), Camisa = 24, Altura = 1.78, Peso = 73, Posicao = Posicao.Meia, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
    new Jogador { Nome = "Rafael Bastos", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1985, 1, 1), Camisa = 25, Altura = 1.78, Peso = 75, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Moisés Ribeiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1991, 3, 3), Camisa = 26, Altura = 1.79, Peso = 74, Posicao = Posicao.Volante, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
    new Jogador { Nome = "Neném", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1981, 9, 28), Camisa = 27, Altura = 1.76, Peso = 70, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Andrei Girotto", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1992, 2, 17), Camisa = 28, Altura = 1.85, Peso = 78, Posicao = Posicao.Volante, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Lucas Mineiro", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1996, 5, 24), Camisa = 29, Altura = 1.83, Peso = 76, Posicao = Posicao.Meia, PePreferido = PePreferido.Direito, TimeId = chapecoense.Id },
    new Jogador { Nome = "Douglas Grolli", Nacionalidade = "Brasileiro", DataNascimento = new DateTime(1989, 10, 5), Camisa = 30, Altura = 1.85, Peso = 80, Posicao = Posicao.Zagueiro, PePreferido = PePreferido.Esquerdo, TimeId = chapecoense.Id },
                };
                context.Jogadores.AddRange(jogadores);
                context.SaveChanges();
            }
            if (chapecoense != null && !context.Comissaos.Any(j => j.TimeId == chapecoense.Id))
            {
                var comissao = new List<Comissao>
    {
        new Comissao { Nome = "Gilmar Dal Pozzo", DataNascimento = new DateTime(1969, 10, 1), Cargo = Cargo.Treinador, TimeId = chapecoense.Id },
        new Comissao { Nome = "Eduardo Silva", DataNascimento = new DateTime(1977, 2, 12), Cargo = Cargo.Auxiliar, TimeId = chapecoense.Id },
        new Comissao { Nome = "Tiago Rocha", DataNascimento = new DateTime(1984, 6, 17), Cargo = Cargo.PreparadorFisico, TimeId = chapecoense.Id },
        new Comissao { Nome = "Bruno Teixeira", DataNascimento = new DateTime(1981, 4, 9), Cargo = Cargo.Fisiologista, TimeId = chapecoense.Id },
        new Comissao { Nome = "Alessandro Lima", DataNascimento = new DateTime(1980, 11, 3), Cargo = Cargo.TreinadorGoleiros, TimeId = chapecoense.Id },
    };

                context.Comissaos.AddRange(comissao);
                context.SaveChanges();
            }
        }
    }
}
