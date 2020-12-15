using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TemplateMaterialDesignAdmin.Models.Candidato;

namespace TemplateMaterialDesignAdmin.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly Candidato _candidato = new Candidato();
        // GET: CandidatoController
        public ActionResult Index()
        {
            ViewBag.Genero = new SelectList
                (
                    new List<dynamic>() {
                        new { 
                         Value = "Masculino",
                         Text = "Masculino"
                        },
                        new {
                         Value = "Feminino",
                         Text = "Masculino"
                        }
                    },
                    "Value",
                    "Text"
                );

            _candidato.Certificados = null;
            _candidato.TrajetoriaProfissional = null;
            return View();
        }

        // GET: CandidatoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CandidatoController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddCertificados(List<IFormFile> arquivos)
        {
            if (arquivos.Count > 0)
            {
                try
                {
                    long tamanhoArquivos = arquivos.Sum(f => f.Length);
                    var caminhoArquivo = Path.GetTempFileName();

                    // processa os arquivo enviados
                    //percorre a lista de arquivos selecionados
                    foreach (var arquivo in arquivos)
                    {
                        //verifica se existem arquivos 
                        if (arquivo == null || arquivo.Length == 0)
                        {
                            throw new ArgumentNullException("Arquivo null.");
                        }
                        // < define a pasta onde vamos salvar os arquivos >
                        string pasta = "Arquivos_Usuario";
                        string nomeArquivo = "Usuario_arquivo_" + $"{arquivo.FileName}" + DateTime.Now.Millisecond.ToString();
                        if (arquivo.FileName.Contains(".jpg"))
                            nomeArquivo += ".jpg";
                        else if (arquivo.FileName.Contains(".gif"))
                            nomeArquivo += ".gif";
                        else if (arquivo.FileName.Contains(".png"))
                            nomeArquivo += ".png";
                        else if (arquivo.FileName.Contains(".pdf"))
                            nomeArquivo += ".pdf";
                        else
                        {
                            ViewData["Erro"] = $"Error: Arquivo {arquivo.FileName} não está no formato adequado.";
                            _candidato.Certificados = null;
                            return View(ViewData);
                        }
                        Certificado certificado = new Certificado();
                        certificado.Nome = nomeArquivo;

                        using (var ms = new MemoryStream())
                        {
                            arquivo.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            string s = Convert.ToBase64String(fileBytes);
                            certificado.DadosBase64 = s;
                        }
                        _candidato.AddCertificados(certificado);
                    }
                    ViewData["Resultado"] = $"{arquivos.Count} arquivos foram enviados ao servidor, " +
                     $"com tamanho total de : {tamanhoArquivos} bytes";
                }
                catch (Exception ex)
                {
                    _candidato.Certificados = null;
                    ViewData["Erro"] = $"{ex.Message}";
                    return View(ViewData);
                }
            }
            return View(ViewData);
        }

        // POST: CandidatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidatoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidatoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidatoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidatoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
