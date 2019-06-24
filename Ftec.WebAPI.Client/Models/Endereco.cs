using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ftec.WebAPI.Client.Models
{
    public class Endereco
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string Complementa { get; set; }
    }
}