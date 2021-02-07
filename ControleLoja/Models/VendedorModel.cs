using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleLoja.Models
{
    public class VendedorModel
    {
        public int Id { get; set; }


        [Display(Name = "Nome", Prompt = "")]
        public string Nome { get; set; }

        [Display(Name = "Email", Prompt = "")]
        public string Email { get; set; }

        [Display(Name = "Senha", Prompt = "")]
        public string Senha { get; set; }
    }
}
