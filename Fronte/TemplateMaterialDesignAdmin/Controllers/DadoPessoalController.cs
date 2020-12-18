using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TemplateMaterialDesignAdmin.Models.Colaborador;
using TemplateMaterialDesignAdmin.Models.DealMaker;
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

            List<DealMaker> dealMakers = new List<DealMaker>();

            if (result.Sucesso)
            {
                var json = JsonConvert.SerializeObject(result.Data);
                dealMakers = JsonConvert.DeserializeObject<List<DealMaker>>(json);
            }

            return View(dealMakers);
        }

        [HttpPost]
        public ActionResult Create(DealMakerInsertCommand data)
        {
            _colaboradorService.Inserir(data).GetAwaiter().GetResult();

            return RedirectToAction("Index", "Home");
        }
    }
}
