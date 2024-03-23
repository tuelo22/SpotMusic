using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Core.Enum;
using SpotMusic.Domain.Notificacao.Aggregates;
using SpotMusic.Domain.Notificacao.Enum;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;
using SpotMusic.Domain.Transacao.Aggregates;
using SpotMusic.Domain.Transacao.ValueObject;
using System.Drawing;

namespace SpotMusic.Tests.NotificacaoTest
{
    public class NotificacaoTest
    {
        [Fact]
        public void DeveCriarUmaNotificacaoComSucesso()
        {
            var plano = Plano.Criar(
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
            String telefone = "991902196";

            //Act
            Usuario usuario = new()
            {
                Id = Guid.NewGuid(),
            };
            usuario.CriarConta(nome, email, senha, telefone, DateTime.Now, plano, cartao);

            string titulo = "Oi to aqui";
            string mensagem = "Não to não, sei lá";

            var notificacao = Notificacao.Criar(titulo, mensagem, TipoNotificacao.Sistema, usuario);

            Assert.Equal(usuario.Id, notificacao.Destinatario.Id);
            Assert.Equal(titulo, notificacao.Titulo);
            Assert.Equal(mensagem, notificacao.Mensagem);
            Assert.Equal(TipoNotificacao.Sistema, notificacao.TipoNotificacao);
        }

        [Fact]
        public void NaoDeveCriarUmaNotificacaoComTipoUsuarioSemDestinatario()
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

            string nome = "Dummy Usuario";
            string email = "teste@teste.com";
            string senha = "123456";
            String telefone = "991902196";
            //Act
            Usuario usuario = new()
            {
                Id = Guid.NewGuid(),
            };
            usuario.CriarConta(nome, email, senha, telefone, DateTime.Now, plano, cartao);

            string titulo = "Oi to aqui";
            string mensagem = "Não to não, sei lá";

            Assert.Throws<Exception>(() =>
            {
                var notificacao = Notificacao.Criar(titulo, mensagem, TipoNotificacao.Usuario, usuario);
            });
        }

        [Fact]
        public void NaoDeveCriarUmaNotificacaoSemTitulo()
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

            string nome = "Dummy Usuario";
            string email = "teste@teste.com";
            string senha = "123456";
            string telefone = "2121212231";

            //Act
            Usuario usuario = new()
            {
                Id = Guid.NewGuid(),
            };
            usuario.CriarConta(nome, email, senha, telefone, DateTime.Now, plano, cartao);

            string titulo = "";
            string mensagem = "Não to não, sei lá";

            Assert.Throws<Exception>(() =>
            {
                var notificacao = Notificacao.Criar(titulo, mensagem, TipoNotificacao.Sistema, usuario);
            });
        }

        [Fact]
        public void NaoDeveCriarUmaNotificacaoSemMensagem()
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

            string nome = "Dummy Usuario";
            string email = "teste@teste.com";
            string senha = "123456";
            string telefone = "2121212231";
            //Act
            Usuario usuario = new()
            {
                Id = Guid.NewGuid(),
            };
            usuario.CriarConta(nome, email, senha, telefone, DateTime.Now, plano, cartao);

            string titulo = "Oi to aqui";
            string mensagem = "";

            Assert.Throws<Exception>(() =>
            {
                var notificacao = Notificacao.Criar(titulo, mensagem, TipoNotificacao.Sistema, usuario);
            });
        }
    }

}
