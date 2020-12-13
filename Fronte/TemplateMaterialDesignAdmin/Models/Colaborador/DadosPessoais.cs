using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateMaterialDesignAdmin.Enums.Colaborador;

namespace TemplateMaterialDesignAdmin.Models.Colaborador
{
    public class DadosPessoais
    {
        public string NomeCompleto { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int DDD { get; set; }
        public string Telefone { get; set; }
        public string ContatoRecado { get; set; }
        public int DDDRecago { get; set; }
        public string TelefoneRecago { get; set; }
        public ESexo Genero { get; set; }
        public EEstadoCivil EstadoCivil { get; set; }
    }
}
