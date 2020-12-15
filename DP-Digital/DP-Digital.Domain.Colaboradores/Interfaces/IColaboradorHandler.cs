using DP_Digital.Domain.Colaboradores.Commands;
using DP_Digital.Domain.Colaboradores.Commands.Colaboradores.Request;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DP_Digital.Domain.Colaboradores.Interfaces
{
    public interface IColaboradorHandler
    {
        Task<ColaboradorCommandResult> InserirAsync(ColaboradorInserirCommand request);
        Task<ColaboradorCommandResult> ObterPorIdAsync(Guid id);
        Task<ColaboradorCommandResult> ObterPorNomeAsync(string nome);

        Task<ColaboradorCommandResult> ObterPorCpfAsync(string cpf);

        public IReadOnlyCollection<Notification> Notifications { get; }

        Task<ColaboradorCommandResult> ObterTodos();
    }
}

