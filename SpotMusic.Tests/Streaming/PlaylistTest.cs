using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Core.Enum;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;
using SpotMusic.Domain.Transacao.Aggregates;
using SpotMusic.Domain.Transacao.ValueObject;

namespace SpotMusic.Tests.Streaming
{
    public class PlaylistTest
    {
        [Fact]
        public void DeveCriarComSucesso()
        {
            var plano = Plano.Criar(
                nome: "Plano Dummy",
                descricao: "Lorem ipsum",
                valor: 19.90M,
                vigencia: Periodo.Criar(Convert.ToDateTime("01/01/2023"), Convert.ToDateTime("31/12/2023")));

            plano.Id = Guid.NewGuid();

            String Estado = "Rio de Janeiro";
            String Cidade = "São Gonçalo";
            String Rua = "Rua dos bobos";
            String Numero = "0";
            String Complemento = "Tão tão distante";

            var endereco = Endereco.Criar(Estado, Cidade, Rua, Numero, Complemento);

            Cartao cartao = new()
            {
                Id = Guid.NewGuid(),
                Status = TipoStatus.Ativo,
                Limite = 1000M,
                Numero = "6465465466",
                EnderecoCobranca = endereco
            };

            string nomeUsuario = "Dummy Usuario";
            string email = "teste@teste.com";
            string senha = "123456";

            //Act
            Usuario usuario = new()
            {
                Id = Guid.NewGuid(),
            };
            usuario.CriarConta(nomeUsuario, email, senha, DateTime.Now, plano, cartao);

            var nome = "Samba";

            var playList = Playlist.Criar(nome, Domain.Streaming.Enum.TipoPlayList.Padrao, usuario, false);

            Assert.Equal(playList.Nome, nome);
            Assert.Equal(playList.Autor.Id, usuario.Id);
        }
        [Fact]
        public void NaoDeveCriarSemNome()
        {
            var plano = Plano.Criar(
                nome: "Plano Dummy",
                descricao: "Lorem ipsum",
                valor: 19.90M,
                vigencia: Periodo.Criar(Convert.ToDateTime("01/01/2023"), Convert.ToDateTime("31/12/2023")));

            plano.Id = Guid.NewGuid();

            String Estado = "Rio de Janeiro";
            String Cidade = "São Gonçalo";
            String Rua = "Rua dos bobos";
            String Numero = "0";
            String Complemento = "Tão tão distante";

            var endereco = Endereco.Criar(Estado, Cidade, Rua, Numero, Complemento);

            Cartao cartao = new()
            {
                Id = Guid.NewGuid(),
                Status = TipoStatus.Ativo,
                Limite = 1000M,
                Numero = "6465465466",
                EnderecoCobranca = endereco
            };

            string nomeUsuario = "Dummy Usuario";
            string email = "teste@teste.com";
            string senha = "123456";

            //Act
            Usuario usuario = new()
            {
                Id = Guid.NewGuid(),
            };
            usuario.CriarConta(nomeUsuario, email, senha, DateTime.Now, plano, cartao);

            var nome = "Samba";

            Assert.Throws<Exception>(() =>
            {
                var playList = Playlist.Criar("", Domain.Streaming.Enum.TipoPlayList.Padrao, usuario, false);
            });
        }
    }
}
