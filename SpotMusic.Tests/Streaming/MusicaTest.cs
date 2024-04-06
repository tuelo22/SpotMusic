using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Tests.Streaming
{
    public class MusicaTest
    {
        [Fact]
        public void DeveCriarComSucesso()
        {
            var nome = "O drama da pos";
            var autor = Autor.Criar("Ze Maria");
            autor.Id = Guid.NewGuid(); 
            var estilo = EstiloMusical.Criar("Rock");
            estilo.Id = Guid.NewGuid();

            var autores = new List<Autor>
            {
                autor
            };

            var musica = Musica.Criar(nome, nome, estilo, autores);

            Assert.Equal(musica.Nome, nome);
            Assert.Equal(musica.Letra, nome);
            Assert.True(musica.Autores.Any());
        }

        [Fact]
        public void NaoDeveCriarSemNome()
        {
            var nome = "";
            var autor = Autor.Criar("Ze Maria");
            autor.Id = Guid.NewGuid();
            var estilo = EstiloMusical.Criar("Rock");
            estilo.Id = Guid.NewGuid();

            var autores = new List<Autor>
            {
                autor
            };

            Assert.Throws<Exception>(() =>
            {
                var musica = Musica.Criar(nome, nome, estilo, autores);
            });
        }
    }
}
