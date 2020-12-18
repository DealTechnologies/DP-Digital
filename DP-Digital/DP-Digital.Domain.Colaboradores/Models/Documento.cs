using System;
using System.Collections.Generic;
using System.Text;

namespace DP_Digital.Domain.Colaboradores.Models
{
    public class Documento
    {
        public string Arquivo { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public string DataEmissao { get; set; }
        public string EstadoEmissao { get; set; }
        public string OrgaoEmissor { get; set; }
        public string Validade { get; set; }
    }
}
