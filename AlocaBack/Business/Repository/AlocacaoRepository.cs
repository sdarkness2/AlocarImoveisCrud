using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Dapper;
using AlocaBack.Business.DTO;
using MySql.Data.MySqlClient;
using System;
using AlocaBack.Business.Interface;

namespace AlocaBack.Business.Repository
{
    public class AlocacaoRepository: IAlocacaoRepository
    {
        private readonly string ConnectionString = "Server=localhost;Database=alocacao;Uid=root;Pwd=12345678;";

        public async Task<IEnumerable<ImoveisDTO>> VerTodos()
        {
            try
            {
                const string qry = "Select * from imoveis";
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    return await conn.QueryAsync<ImoveisDTO>(qry);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ImoveisDTO>> VerImoveisAtivos()
        {
            try
            {
                const string qry = "Select * from imoveis where disponivel = 1";
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    return await conn.QueryAsync<ImoveisDTO>(qry);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ImoveisDTO>> VerImoveisPorId(string id)
        {
            try
            {
                var obj = new {Id = id};
                const string qry = "Select * from imoveis where id = @Id";
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    return await conn.QueryAsync<ImoveisDTO>(qry, obj);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task EditarImovel(ImoveisDTO imovel)
        {
            try
            {
                const string qry = @"UPDATE imoveis SET RUA = @Rua, BAIRRO = @Bairro, NUMERO = @Numero,
                                    CIDADE = @Cidade, TIPO = @Tipo WHERE ID=@Id";
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    await conn.ExecuteAsync(qry, imovel);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task AdicionarImovel(ImoveisDTO imovel)
        {
            try
            {
                const string qry = @"INSERT INTO IMOVEIS(tipo, rua, numero, bairro, cidade, estado, disponivel, preco, datainicial)
                                VALUES(@Tipo, @Rua, @Numero, @Bairro, @Cidade, @Estado, 1, @Preco, @DataInicial)";
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    await conn.ExecuteAsync(qry, imovel);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ImoveisDTO>> ImovelExiste(ImoveisDTO imovel)
        {
            try
            {
                const string qry = "SELECT * FROM IMOVEIS WHERE RUA = @Rua AND NUMERO = @Numero";
                using(var conn = new MySqlConnection(ConnectionString))
                {
                    return await conn.QueryAsync<ImoveisDTO>(qry, imovel);
                }
            }
            catch
            {
                
                throw;
            }
        }

        public async Task DesativarImovel(string id)
        {
            try
            {
                var obj = new {Id = id, DataFinal = new DateTime()};
                const string qry = "UPDATE IMOVEIS SET DISPONIVEL = 0, DATAFINAL = @DataFinal WHERE ID = @Id";
                using(var conn = new MySqlConnection(ConnectionString))
                {
                    await conn.ExecuteAsync(qry, obj);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}