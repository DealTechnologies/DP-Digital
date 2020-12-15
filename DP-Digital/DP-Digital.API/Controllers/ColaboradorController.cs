using DP_Digital.Domain.Colaboradores.Commands;
using DP_Digital.Domain.Colaboradores.Commands.Colaboradores.Request;
using DP_Digital.Domain.Colaboradores.Interfaces;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DP_Digital.API.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorHandler _colaboradorHandler;

        public ColaboradorController(IColaboradorHandler colaboradorHandler)
        {
            _colaboradorHandler = colaboradorHandler;
        }

        [HttpGet]
        [Route("v1/Colaborador/ObterPorID/{id:Guid}")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            try
            {
                var result = await _colaboradorHandler.ObterPorIdAsync(id);


                if (result is null)
                {
                    ColaboradorCommandResult retorno = new ColaboradorCommandResult("Apresentou um erro", _colaboradorHandler.Notifications);
                    return BadRequest(retorno);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                ColaboradorCommandResult retorno = new ColaboradorCommandResult("Erro interno no servidor", new List<Notification>() { new Notification($"{ex.Message}", "InternalServerError") });
                return StatusCode(StatusCodes.Status500InternalServerError, retorno);
            }
        }

        [HttpGet]
        [Route("v1/Colaborador/ObterPorNome/{nome}")]
        public async Task<IActionResult> ObterPorIdAsync(string nome)
        {
            try
            {
                var result = await _colaboradorHandler.ObterPorNomeAsync(nome);


                if (result is null)
                {
                    ColaboradorCommandResult retorno = new ColaboradorCommandResult("Apresentou um erro", _colaboradorHandler.Notifications);
                    return BadRequest(retorno);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                ColaboradorCommandResult retorno = new ColaboradorCommandResult("Erro interno no servidor", new List<Notification>() { new Notification($"{ex.Message}", "InternalServerError") });
                return StatusCode(StatusCodes.Status500InternalServerError, retorno);
            }
        }


        [HttpGet]
        [Route("v1/Colaborador/ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var result = await _colaboradorHandler.ObterTodos();


                if (result is null)
                {
                    ColaboradorCommandResult retorno = new ColaboradorCommandResult("Apresentou um erro", _colaboradorHandler.Notifications);
                    return BadRequest(retorno);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                ColaboradorCommandResult retorno = new ColaboradorCommandResult("Erro interno no servidor", new List<Notification>() { new Notification($"{ex.Message}", "InternalServerError") });
                return StatusCode(StatusCodes.Status500InternalServerError, retorno);
            }
        }

        [HttpPost]
        [Route("v1/Colaborador/Inserir")]
        public async Task<IActionResult> InserirAsync([FromBody] ColaboradorInserirCommand parametros)
        {
            try
            {

                if (parametros == null)
                {
                    ColaboradorCommandResult retorno = new ColaboradorCommandResult("Apresentou um erro", new List<Notification>() { new Notification("Dados de entrada inválidos.", "Command") });
                    return BadRequest(retorno);
                }

                if (!parametros.ValidarCampos())
                {
                    ColaboradorCommandResult retorno = new ColaboradorCommandResult("Apresentou um erro", new List<Notification>() { new Notification("Id inválido", "BuscaOrigem") });
                    return BadRequest(retorno);
                }

                var result = await _colaboradorHandler.InserirAsync(parametros);

                if (result is null)
                {
                    ColaboradorCommandResult retorno = new ColaboradorCommandResult("Apresentou um erro", _colaboradorHandler.Notifications);
                    return BadRequest(retorno);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                ColaboradorCommandResult retorno = new ColaboradorCommandResult("Erro interno no servidor", new List<Notification>() { new Notification($"{ex.Message}", "InternalServerError") });
                return StatusCode(StatusCodes.Status500InternalServerError, retorno);
            }
        }
    }
}
