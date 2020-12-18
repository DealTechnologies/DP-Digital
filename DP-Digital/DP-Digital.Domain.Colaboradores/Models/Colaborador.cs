using DP_Digital.Domain.Colaboradores.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP_Digital.Domain.Colaboradores.Models
{
    public class Colaborador 
    {
        public Colaborador()
        {
            Id = Guid.NewGuid();
        }

        public Colaborador(Guid id)
        {
            Id = id;
        }

        [BsonId]
        public Guid Id { get; private set; }
        public DadosSociais DadosSociais { get; set; }
        public Documento Documento { get; set; }
        public CarteiraTrabalho CarteiraTrabalho { get; set; }
        public TituloEleitor TituloEleitor { get; set; }
        public PIS PIS { get; set; }
        public Naturalidade Naturalidade { get; set; }
        public RedesSociais RedesSociais { get; set; }
        public DadosFisicos DadosFisicos { get; set; }
        public List<Dependente> Dependentes { get; set; }
        public List<Formacao> Formacoes { get; set; }
        public List<ExperienciaProfissional> ExperienciasProfissionais { get; set; }
        public List<Certificacao> Certificacoes { get; set; }
    }
}
