using DP_Digital.Domain.Colaboradores.Enum;
using System;

namespace DP_Digital.Domain.Colaboradores.Models
{
    public class Dependente
    {
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public string GrauParentesco { get; set; }
        public string DataNascimento { get; set; }
        public string EstadoNascimento { get; set; }
        public string Nacionalidade { get; set; }
    }
}
