using System;
using System.Threading.Tasks;
using TemplateMaterialDesignAdmin.Models.Colaborador.Commands;
using TemplateMaterialDesignAdmin.Models.Results;

namespace TemplateMaterialDesignAdmin.Services.Interfaces
{
    public interface IColaboradorService
    {
        Task<CommandResult> Inserir(ColaboradorInserirCommand command);
        Task<CommandResult> Atualizar(ColaboradorAtualizarCommand command);
        Task<CommandResult> Remover(Guid id);
        Task<CommandResult> ObterTodos();
        Task<CommandResult> ObterPorId(Guid id);
        Task<CommandResult> ObterPorNome(string nome);
        Task<CommandResult> ObterPorCPF(string cpf);
    }
}