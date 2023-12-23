using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Core.Enum;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;
using SpotMusic.Domain.Transacao.Aggregates;
using SpotMusic.Domain.Transacao.ValueObject;

namespace SpotMusic.Tests.ContaTest
{
    public class UsuarioTest
    {
        [Fact]
        public void DeveCriarUsuarioComSucesso()
        {
            var plano =
                Plano.Criar(
                    nome: "Plano Dummy",
                    descricao: "Lorem ipsum",
                    valor: 19.90M,
                    vigencia: Periodo.Criar(Convert.ToDateTime("01/01/2023"), Convert.ToDateTime("31/12/2023"))
                );
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

            string nome = "Dummy Usuario";
            string email = "teste@teste.com";
            string senha = "123456";


            //Act
            Usuario usuario = new();
            usuario.CriarConta(nome, email, senha, DateTime.Now, plano, cartao);

            //Assert
            Assert.NotNull(usuario.Email);
            Assert.NotNull(usuario.Nome);
            Assert.True(usuario.Email == email);
            Assert.True(usuario.Nome == nome);
            Assert.True(usuario.Senha != senha);

            Assert.True(usuario.Assinaturas.Count > 0);
            Assert.Same(usuario.Assinaturas[0].Plano, plano);

            Assert.True(usuario.Cartoes.Count > 0);
            Assert.Same(usuario.Cartoes[0], cartao);

            Assert.True(usuario.Playlists.Count > 0);
            Assert.True(usuario.Playlists[0].Nome == "Favoritas");
            Assert.False(usuario.Playlists[0].Publica);
        }

        [Fact]
        public void NaoDeveCriarUsuarioComCartaoSemLimite()
        {
            var plano =
                Plano.Criar(
                    nome: "Plano Dummy",
                    descricao: "Lorem ipsum",
                    valor: 19.90M,
                    vigencia: Periodo.Criar(Convert.ToDateTime("01/01/2023"), Convert.ToDateTime("31/12/2023"))
                );
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
                Limite = 10M,
                Numero = "6465465466",
                EnderecoCobranca = endereco
            };

            string nome = "Dummy Usuario";
            string email = "teste@teste.com";
            string senha = "123456";

            //Act
            Assert.Throws<Exception>(() =>
            {
                Usuario usuario = new();
                usuario.CriarConta(nome, email, senha, DateTime.Now, plano, cartao);
            });
        }
    }
}
