using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace precificacaointeligente.Models
{
    public class Usuario
    {
        [Key]  // ← ESSENCIAL
        public int Id { get; set; }


        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
        public DateTime DataCadastro { get; set; }

        public ICollection<Relatorio> Relatorios { get; set; }
    }
}
