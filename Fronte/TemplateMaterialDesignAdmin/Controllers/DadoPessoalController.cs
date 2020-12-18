using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TemplateMaterialDesignAdmin.Models.Colaborador;
using TemplateMaterialDesignAdmin.Models.DealMaker.Commads;
using TemplateMaterialDesignAdmin.Models.Results;
using TemplateMaterialDesignAdmin.Services.Interfaces;

namespace TemplateMaterialDesignAdmin.Controllers
{
    public class DadoPessoalController : Controller
    {
        private readonly IColaboradorService _colaboradorService;

        public DadoPessoalController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            CommandResult result = _colaboradorService.ObterTodos().GetAwaiter().GetResult();

            List<Colaborador> colaboradores = new List<Colaborador>();

            if (result.Sucesso)
            {
                var json = JsonConvert.SerializeObject(result.Data);
                colaboradores = JsonConvert.DeserializeObject<List<Colaborador>>(json);
            }

            return View(colaboradores);
        }

        [HttpPost]
        public ActionResult Create(DealMakerInsertCommand data)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
