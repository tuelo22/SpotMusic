using SpotMusic.Domain.Core.Enum;
using SpotMusic.Domain.Core.ValueObject;
using SpotMusic.Domain.Extensions;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.Enum;
using SpotMusic.Domain.Transacao.Aggregates;
using SpotMusic.Domain.Transacao.ValueObject;
using System.Security.Cryptography;
using System.Text;

namespace SpotMusic.Domain.Conta.Aggregates
{
    public class Usuario
    {
        private const string PLAYLISTFAVORITA = "Favoritas";
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual IList<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public virtual IList<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual IList<Notificacao.Aggregates.Notificacao> Notificacoes { get; set; } = new List<Notificacao.Aggregates.Notificacao>();

        public void CriarConta(String nome, String email, String senha, String Telefone,DateTime dataNascimento, Plano plano, Cartao cartao)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha.Criptografar();
            this.DataNascimento = dataNascimento;
            this.Telefone = Telefone;
            this.AssinarPlano(plano, cartao);
            this.AdicionarCarto(cartao);
            this.CriarPlayList();
        }

        private void AdicionarCarto(Cartao cartao) => this.Cartoes.Add(cartao);

        private void CriarPlayList()
        {
            CriarPlayList(PLAYLISTFAVORITA, false);
        }

        private void CriarPlayList(string nome, bool publica)
        {
            this.Playlists.Add(new Playlist()
            {
                Nome = nome,
                Autor = this,
                Publica = publica,
                TipoPlayList = TipoPlayList.Favorita,
                DataCriacao = DateTime.Now
            });
        }

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            cartao.CriarTransacao(
                Merchant.Criar(plano.Nome),
                new Monetario(plano.Valor),
                plano.Nome);

            DesativarAssinaturaAtiva();

            this.Assinaturas.Add(Assinatura.Criar(
                plano: plano,
                DataInicio: DateTime.Now
            ));
        }

        private void DesativarAssinaturaAtiva()
        {
            if (this.Assinaturas.Count > 0 && this.Assinaturas.Any(x => x.Status == TipoStatus.Ativo))
            {
                var assinatura = this.Assinaturas.FirstOrDefault(x => x.Status == TipoStatus.Ativo);

                assinatura?.Inativar();
            }
        }
    }
}
