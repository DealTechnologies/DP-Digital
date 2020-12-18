using System.Collections.Generic;

namespace TemplateMaterialDesignAdmin.Models.DealMaker.Commads
{
    public class DealMakerInsertCommand
    {
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