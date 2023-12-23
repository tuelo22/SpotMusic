using SpotMusic.Domain.Core.Enum;
using SpotMusic.Domain.Core.ValueObject;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.Enum;
using SpotMusic.Domain.Streaming.ValueObject;
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
        public List<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
        public List<Notificacao.Aggregates.Notificacao> Notificacoes { get; set; } = new List<Notificacao.Aggregates.Notificacao>();

        public void CriarConta(String nome, String email, String senha, DateTime dataNascimento, Plano plano, Cartao cartao)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = CriptografarSenha(senha);
            this.DataNascimento = dataNascimento;
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
                new Merchant(plano.Nome),
                new Monetario(plano.Valor),
                plano.Descricao);

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

        private static String CriptografarSenha(string senhaAberta)
        {
            //BCript
            SHA256 criptoProvider = SHA256.Create();

            byte[] texto = Encoding.UTF8.GetBytes(senhaAberta);

            var criptoResult = criptoProvider.ComputeHash(texto);

            return Convert.ToHexString(criptoResult);
        }
    }
}
