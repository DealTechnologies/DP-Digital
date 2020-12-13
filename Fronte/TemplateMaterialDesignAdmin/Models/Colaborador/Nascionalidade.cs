using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateMaterialDesignAdmin.Enums.Colaborador;

namespace TemplateMaterialDesignAdmin.Models.Colaborador
{
    public class NascionalidadeGeral
    {
        public ENacionalidade Nascionalidade { get; set; }
        public ENacionalidade UfDeNascimento { get; set; }
        public ENacionalidade CidadeNascimento { get; set; }
    }
    
}
