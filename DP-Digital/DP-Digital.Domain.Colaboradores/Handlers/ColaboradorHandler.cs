using DP_Digital.Domain.Colaboradores.Commands;
using DP_Digital.Domain.Colaboradores.Commands.Colaboradores.Request;
using DP_Digital.Domain.Colaboradores.Interfaces;
using DP_Digital.Domain.Colaboradores.Models;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DP_Digital.Domain.Colaboradores.Handlers
{
    public class ColaboradorHandler : Notifiable, IColaboradorHandler
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }


        public async Task<ColaboradorCommandResult> InserirAsync(ColaboradorInserirCommand request)
        {
            try
            {
                Colaborador colaborador = GerarColaborador(request);

                await _colaboradorRepository.InserirAsync(colaborador);

                return new ColaboradorCommandResult("Candidato Inserido com Suacesso", colaborador);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public async Task<ColaboradorCommandResult> ObterPorIdAsync(Guid id)
        {
            try
            {
                var retorno = await _colaboradorRepository.ObterPorIdAsync(id);

                if (retorno == null)
                {
                    AddNotification("Candidato", "Não existe candidato com esse ID");
                    return null;
                }

                return new ColaboradorCommandResult("Consulta Realizada com sucesso.", retorno);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<ColaboradorCommandResult> ObterTodos()
        {
            try
            {
                var retorno = await _colaboradorRepository.ObterTodosAsync();

                if (retorno == null)
                {
                    AddNotification("Candidato", "Não existe candidato com esse ID");
                    return null;
                }

                return new ColaboradorCommandResult("Consulta Realizada com sucesso.", retorno);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ColaboradorCommandResult> ObterPorNomeAsync(string nome)
        {
            try
            {
                var retorno = await _colaboradorRepository.ObterPorNomeAsync(nome);

                if (retorno == null)
                {
                    AddNotification("Candidato", "Não existe candidato com esse Nome");
                    return null;
                }

                return new ColaboradorCommandResult("Consulta Realizada com sucesso.", retorno);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ColaboradorCommandResult> ObterPorCpfAsync(string cpf)
        {
            try
            {
                var retorno = await _colaboradorRepository.ObterPorCpfAsync(cpf);

                if (retorno == null)
                {
                    AddNotification("Candidato", "Não existe candidato com esse CPF");
                    return null;
                }

                return new ColaboradorCommandResult("Consulta Realizada com sucesso.", retorno);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Colaborador GerarColaborador(ColaboradorInserirCommand request)
        {
            Colaborador colaborador = new Colaborador();

            colaborador.DadosFisicos = request.DadosFisicos;
            colaborador.DadosSociais = request.DadosSociais;
            colaborador.CarteiraTrabalho = request.CarteiraTrabalho;
            colaborador.Certificacoes = request.Certificacoes;
            colaborador.Dependentes = request.Dependentes;
            colaborador.Documento = request.Documento;
            colaborador.ExperienciasProfissionais = request.ExperienciasProfissionais;
            colaborador.Formacoes = request.Formacoes;
            colaborador.Naturalidade = request.Naturalidade;
            colaborador.PIS = request.PIS;
            colaborador.RedesSociais = request.RedesSociais;
            colaborador.TituloEleitor = request.TituloEleitor;

            return colaborador;
        }

    }
}
