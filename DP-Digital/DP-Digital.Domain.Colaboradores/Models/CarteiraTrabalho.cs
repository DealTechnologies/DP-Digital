using System;
using System.Collections.Generic;
using System.Text;

namespace DP_Digital.Domain.Colaboradores.Models
{
    public class CarteiraTrabalho
    {
        public string Arquivo { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public string EstadoEmissao { get; set; }
        public string DataEmissao { get; set; }
        public string DataValidade { get; set; }
    }
}
