using DP_Digital.Domain.Colaboradores.Interfaces;
using DP_Digital.Domain.Colaboradores.Models;
using DP_Digital.Infra.Candidatos.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DP_Digital.Infra.Colaboradores.Repositorys
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly MongoDBContext _mongoDBContext;
        private readonly string _collection;

        public ColaboradorRepository(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _collection = "Colaborador";
        }

        public async Task InserirAsync(Colaborador colaborador)
        {
            var collection = _mongoDBContext.MongoDBConexao.GetCollection<Colaborador>(_collection);

            await collection.InsertOneAsync(colaborador);
        }


        public async Task AtualizarAsync(Colaborador colaborador)
        {
            await RemoverAsync(colaborador.Id);

            await InserirAsync(colaborador);
        }


        public async Task RemoverAsync(Guid id)
        {
            var collection = _mongoDBContext.MongoDBConexao.GetCollection<Colaborador>(_collection);

            Expression<Func<Colaborador, bool>> filter = x => x.Id == id;
            await collection.DeleteOneAsync(filter);
        }


        public async Task<Colaborador> ObterPorNomeAsync(string nome)
        {
            var collection = _mongoDBContext.MongoDBConexao.GetCollection<Colaborador>(_collection);

            Expression<Func<Colaborador, bool>> filter = x => x.NomeCompleto.ToUpper() == nome.ToUpper();

            var retorno = await collection.FindAsync<Colaborador>(filter);

            return retorno.FirstOrDefault();
        }

        public async Task<Colaborador> ObterPorCpfAsync(string cpf)
        {
            var collection = _mongoDBContext.MongoDBConexao.GetCollection<Colaborador>(_collection);

            Expression<Func<Colaborador, bool>> filter = x => x.CPF.ToUpper() == cpf.ToUpper();

            var retorno = await collection.FindAsync<Colaborador>(filter);

            return retorno.FirstOrDefault();
        }

        public async Task<Colaborador> ObterPorIdAsync(Guid id)
        {
            var collection = _mongoDBContext.MongoDBConexao.GetCollection<Colaborador>(_collection);

            Expression<Func<Colaborador, bool>> filter = x => x.Id == id;

            var retorno = await collection.FindAsync<Colaborador>(filter);

            return retorno.FirstOrDefault();
        }


        public async Task<List<Colaborador>> ObterTodosAsync()
        {
            var collection = _mongoDBContext.MongoDBConexao.GetCollection<Colaborador>(_collection);

            var retorno = await collection.FindAsync<Colaborador>(new BsonDocument());

            return retorno.ToList();
        }
    }
}
