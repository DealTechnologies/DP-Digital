using System;
using System.Collections.Generic;
using System.Text;

namespace DP_Digital.Domain.Colaboradores.Models
{
    public class Formacao
    {
        public string Curso { get; set; }
        public string Tipo { get; set; }
        public string Instituicao { get; set; }
        public string TotalHoras { get; set; }
        public string DataInicio { get; set; }
        public string DataConclusao { get; set; }
        public string Idioma { get; set; }
        public string Preferencia { get; set; }
    }
}
