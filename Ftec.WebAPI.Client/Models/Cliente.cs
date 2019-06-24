using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ftec.WebAPI.Client.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataFundacao { get; set; }
        public Endereco Endereco { get; set; }

    }
}