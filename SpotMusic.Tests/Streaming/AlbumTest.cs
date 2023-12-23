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

            var album = Album.Criar(nome, musicas);

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
                var album = Album.Criar("", musicas);
            });
        }
        [Fact]
        public void DeveAdicionarUmaMusicaAoAlbum()
        {
            var nome = "O drama da pos";
            var nome2 = "Aula sem fim";
            var autor = Autor.Criar("Ze Maria");
            var estilo = EstiloMusical.Criar("Rock");

            var autores = new List<Autor>
            {
                autor
            };

            var musicas = new List<Musica>
            {
                Musica.Criar(nome, 10, nome, estilo, autores)
            };

            var musica2 = Musica.Criar(nome2, 10, nome, estilo, autores);
            musica2.Id = Guid.NewGuid();

            var album = Album.Criar(nome, musicas);
            album.AdicionarMusica(musica2);

            Assert.Contains(album.Musicas, x => x.Id == musica2.Id);
        }
    }
}
