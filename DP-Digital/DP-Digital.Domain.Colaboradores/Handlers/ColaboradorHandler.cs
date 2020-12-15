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

            colaborador.NomeCompleto = request.NomeCompleto;
            colaborador.Sexo = request.Sexo;
            colaborador.NomeSocial = request.NomeSocial;
            colaborador.GrauDeInstrucao = request.GrauDeInstrucao;
            colaborador.DataNascimento = request.DataNascimento;
            colaborador.Email = request.Email;
            colaborador.LinkedIn = request.LinkedIn;
            colaborador.DDD = request.DDD;
            colaborador.TelefoneCelular = request.TelefoneCelular;
            colaborador.DDDTelefoneRecado = request.DDDTelefoneRecado;
            colaborador.TelefoneRecado = request.TelefoneRecado;
            colaborador.NomeParaContatoRecado = request.NomeParaContatoRecado;
            colaborador.PaisResidencia = request.PaisResidencia;
            colaborador.CEP = request.CEP;
            colaborador.Endereco = request.Endereco;
            colaborador.Numero = request.Numero;
            colaborador.Complemento = request.Complemento;
            colaborador.Bairro = request.Bairro;
            colaborador.UF = request.UF;
            colaborador.Cidade = request.Cidade;
            colaborador.ComoConheceuEmpresa = request.ComoConheceuEmpresa;
            colaborador.ListaDeInstrucao = request.ListaDeInstrucao;
            colaborador.ListaDeCursoCertificacao = request.ListaDeCursoCertificacao;
            colaborador.ListaDeIdiomas = request.ListaDeIdiomas;
            colaborador.Apresentacao = request.Apresentacao;
            colaborador.CargoPretendido = request.CargoPretendido;
            colaborador.Salario = request.Salario;
            colaborador.ListaDeEmpregoAnterior = request.ListaDeEmpregoAnterior;
            colaborador.EstadoCivil = request.EstadoCivil;
            colaborador.Nacionalidade = request.Nacionalidade;
            colaborador.Naturalizacao = request.Naturalizacao;
            colaborador.ResideNoBrasil = request.ResideNoBrasil;
            colaborador.UFNaturalidade = request.UFNaturalidade;
            colaborador.CidadeNaturalidade = request.CidadeNaturalidade;
            colaborador.NomeDaMae = request.NomeDaMae;
            colaborador.NomeDoPai = request.NomeDoPai;
            colaborador.NomeConjuge = request.NomeConjuge;
            colaborador.PossuiDependente = request.PossuiDependente;
            colaborador.PossuiDeficiencia = request.PossuiDeficiencia;
            colaborador.CPF = request.CPF;
            colaborador.Identidade = request.Identidade;
            colaborador.DataDeEmissao = request.DataDeEmissao;
            colaborador.OrgaoEmissor = request.OrgaoEmissor;
            colaborador.NumeroPIS = request.NumeroPIS;
            colaborador.ListaDeDependentes = request.ListaDeDependentes;
            colaborador.ListaDeDocumentos = request.ListaDeDocumentos;

            return colaborador;
        }

    }
}
