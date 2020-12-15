using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateMaterialDesignAdmin.Models.Colaborador.Commands;
using TemplateMaterialDesignAdmin.Models.Results;
using TemplateMaterialDesignAdmin.Services.Interfaces;

namespace TemplateMaterialDesignAdmin.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly Settings _settings;

        public ColaboradorService(IOptions<Settings> options)
        {
            _settings = options.Value;
        }

        public async Task<CommandResult> Inserir(ColaboradorInserirCommand command)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_settings.DPDIGITAL_API_COLABORADOR);

                string json = JsonConvert.SerializeObject(command);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse;

                using (client)
                {
                    httpResponse = await client.PostAsync(_settings.ENDPOINT_COLABORADOR_INSERIR, httpContent);
                }

                var response = httpResponse.Content.ReadAsStringAsync().Result;
                var retorno = JsonConvert.DeserializeObject<CommandResult>(response);
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CommandResult> Atualizar(ColaboradorAtualizarCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<CommandResult> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CommandResult> ObterTodos()
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uri = new Uri(_settings.DPDIGITAL_API_COLABORADOR + _settings.ENDPOINT_CANDIDATO_OBTERTODOS);

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri
                };

                HttpResponseMessage httpResponse;

                using (client)
                {
                    httpResponse = await client.SendAsync(request);
                }

                var response = httpResponse.Content.ReadAsStringAsync().Result;
                var retorno = JsonConvert.DeserializeObject<CommandResult>(response);
                return retorno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CommandResult> ObterPorId(Guid id)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uri = new Uri(_settings.DPDIGITAL_API_COLABORADOR + _settings.ENDPOINT_COLABORADOR_OBTERPORID + id.ToString());

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri
                };

                HttpResponseMessage httpResponse;

                using (client)
                {
                    httpResponse = await client.SendAsync(request);
                }

                var response = httpResponse.Content.ReadAsStringAsync().Result;
                var retorno = JsonConvert.DeserializeObject<CommandResult>(response);
                return retorno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CommandResult> ObterPorNome(string nome)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uri = new Uri(_settings.DPDIGITAL_API_COLABORADOR + _settings.ENDPOINT_COLABORADOR_OBTERPORNOME + nome);

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri
                };

                HttpResponseMessage httpResponse;

                using (client)
                {
                    httpResponse = await client.SendAsync(request);
                }

                var response = httpResponse.Content.ReadAsStringAsync().Result;
                var retorno = JsonConvert.DeserializeObject<CommandResult>(response);
                return retorno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CommandResult> ObterPorCPF(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}