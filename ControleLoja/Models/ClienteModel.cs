using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleLoja.Models
{
    public class ClienteModel
    {
        public  int Id { get; set; }


        [Display(Name = "Nome", Prompt = "")]

        public string Nome { get; set; }


        [Display(Name = "Cidade", Prompt = "")]
        public string Cidade { get; set; }


        [Display(Name = "Celular", Prompt = "")]
        public string Cel { get; set; }


        [Display(Name = "Email", Prompt = "")]
        public string Email { get; set; }

        public List<ClienteModel> ListaClientes()

        {

            return new List<ClienteModel>

            {

                new ClienteModel { Nome = "Eduardo Pires"},

                new ClienteModel { Nome = "João Silva"},

                new ClienteModel { Nome = "Fulano de Tal" }

            };

        }

    }
}
