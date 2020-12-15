using DP_Digital.Domain.Colaboradores.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DP_Digital.Domain.Colaboradores.Interfaces
{
    public interface IColaboradorRepository
    {
        Task InserirAsync(Colaborador colaborador);
        Task AtualizarAsync(Colaborador colaborador);

        Task RemoverAsync(Guid id);

        Task<Colaborador> ObterPorNomeAsync(string nome);

        Task<Colaborador> ObterPorIdAsync(Guid id);


        Task<Colaborador> ObterPorCpfAsync(string cpf);

        Task<List<Colaborador>> ObterTodosAsync();

    }
}
