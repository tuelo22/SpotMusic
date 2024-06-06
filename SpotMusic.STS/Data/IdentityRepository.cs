using Dapper;
using Microsoft.Extensions.Options;
using SpotMusic.STS.Model;
using System.Data.SqlClient;

namespace SpotMusic.STS.Data
{
    public class IdentityRepository
    {
        private readonly string connectionString;

        public IdentityRepository(IOptions<DataBaseOption> dataBaseOption)
        {
            connectionString = dataBaseOption.Value.SpotMusicConnection;
        }

        public async Task<Usuario> FindByIdAsync(Guid id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var user = await connection.QueryFirstAsync<Usuario>(IdentityQuery.FindById(), new
                {
                    id = id,
                });

                return user;
            }
        }

        public async Task<Usuario> FindByEmailAndPasswordAsync(string email, string senha)
        {
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    var user = await connection.QueryFirstAsync<Usuario>(IdentityQuery.FindByEmailAndPassword(), new
                    {
                        email = email,
                        senha = senha
                    });

                    return user;
                }
            }
        }
    }

    public static class IdentityQuery
    {
        public static String FindById() =>
            @"SELECT ID, NOME, EMAIL FROM USUARIO WHERE ID = @ID";

        public static String FindByEmailAndPassword() =>
            @"SELECT ID, NOME, EMAIL FROM USUARIO WHERE EMAIL = @EMAIL AND SENHA = @SENHA";
    }
}
