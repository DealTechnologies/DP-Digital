using System;
using System.Collections.Generic;
using TemplateMaterialDesignAdmin.Enums.Colaborador;

namespace TemplateMaterialDesignAdmin.Models.Colaborador
{
    public class Colaborador : Pessoa
    {
        public DadosPessoais DadosPessoais { get; set; }
        public NascionalidadeGeral Nascionalidade { get; set; }
        public InformacoesGerais InformacoesGerais { get; set; }
        public List<Dependentes> Dependentes { get; set; }
    }
}