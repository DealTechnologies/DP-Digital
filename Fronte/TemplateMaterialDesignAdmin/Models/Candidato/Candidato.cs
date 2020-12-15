using System;
using System.Collections.Generic;

namespace TemplateMaterialDesignAdmin.Models.Candidato
{
    public class Candidato
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string DataNascimento { get; set; }
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public string Sexo { get; set; }
        public List<TrajetoriaProfissional> TrajetoriaProfissional { get; set; }
        public List<Certificado> Certificados { get; set; }
        public void AddCertificados(Certificado item)
        {
            if (Certificados == null)
                Certificados = new List<Certificado>();
            Certificados.Add(item);
        }
    }
}