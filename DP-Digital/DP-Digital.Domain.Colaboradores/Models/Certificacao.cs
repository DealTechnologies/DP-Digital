using System;
using System.Collections.Generic;
using System.Text;

namespace DP_Digital.Domain.Colaboradores.Models
{
    public class Certificacao
    {
        public string NomeCurso { get; set; }
        public string Emissor { get; set; }
        public string Instituicao { get; set; }
        public string DataInicio { get; set; }
        public string DataConclusao { get; set; }
        public string CargaHoraria { get; set; }
        public string DiplomaCertificado { get; set; }
    }
}
