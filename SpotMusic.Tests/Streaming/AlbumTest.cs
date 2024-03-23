using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Tests.Streaming
{
    public class AlbumTest
    {
        [Fact]
        public void DeveCriarUmAlbumComSucesso()
        {
            var nome = "O drama da pos";
            var autor = Autor.Criar("Ze Maria");
            var estilo = EstiloMusical.Criar("Rock");

            var autores = new List<Autor>
            {
                autor
            };

            var musica = Musica.Criar(nome, 10, nome, estilo, autores);

            var musicas = new List<Musica>
            {
                musica
            };

            var album = Album.Criar(nome, musicas, autor);

            Assert.Equal(album.Nome, nome);
        }
        [Fact]
        public void NaoDeveCriarUmAlbumSemNome()
        {
            var nome = "O drama da pos";
            var autor = Autor.Criar("Ze Maria");
            var estilo = EstiloMusical.Criar("Rock");

            var autores = new List<Autor>
            {
                autor
            };

            var musica = Musica.Criar(nome, 10, nome, estilo, autores);

            var musicas = new List<Musica>
            {
                musica
            };

            Assert.Throws<Exception>(() =>
            {
                var album = Album.Criar("", musicas, autor);
            });
        }
    }
}
