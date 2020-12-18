using System;

namespace TemplateMaterialDesignAdmin.Models.DealMaker
{
    public class DadosSociais
    {
        public string NomeCompleto { get; set; }
        public string NomeSocial { get; set; }
        public string DataNascimento { get; set; }
        public string Foto { get; set; }
        public string Email { get; set; }
        public string DDDTelefonePessoa { get; set; }
        public string TelefonePessoal { get; set; }
        public string ContatoRecado { get; set; }
        public string DDDTelefoneRecado { get; set; }
        public string TelefoneRecado { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public bool PossuiDeficiencia { get; set; }
        public bool PossuiDependentes { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string NomeConjugue { get; set; }
    }
}