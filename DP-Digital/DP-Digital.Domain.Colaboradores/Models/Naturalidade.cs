using System;
using System.Collections.Generic;
using System.Text;

namespace DP_Digital.Domain.Colaboradores.Models
{
    public class Naturalidade
    {
        public string Nacionalidade { get; set; }
        public bool Naturalizado { get; set; }
        public string UfNascimento { get; set; }
        public string CidadeNascimento { get; set; }
        public string ClassificacaoEstrangeiro { get; set; }
    }
}
