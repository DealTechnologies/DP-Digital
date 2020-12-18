using System;
using System.Collections.Generic;
using System.Text;

namespace DP_Digital.Domain.Colaboradores.Models
{
    public class ExperienciaProfissional
    {
        public string Empresa { get; set; }
        public string Cidade { get; set; }
        public string DataAdmissao { get; set; }
        public string DataDesligamento { get; set; }
        public string Cargo { get; set; }
        public string Senioridade { get; set; }
        public string Remuneracao { get; set; }
        public bool PorHora { get; set; }
        public string Atividades { get; set; }
        public string Tecnologias { get; set; }
    }
}
