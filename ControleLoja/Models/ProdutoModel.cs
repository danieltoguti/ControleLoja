using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleLoja.Models
{
    public class ProdutoModel
    {
        public  int Id { get; set; }


        [Display(Name = "Nome", Prompt = "")]

        public string Nome { get; set; }


        [Display(Name = "Categoria", Prompt = "")]
        public string Categoria { get; set; }


        [Display(Name = "Genero", Prompt = "")]
        public string Genero { get; set; }


        [Display(Name = "Preço Custo", Prompt = "")]
        public double PrecoCusto { get; set; }


        [Display(Name = "Preço Venda", Prompt = "")]
        public double PrecoVenda { get; set; }


        [Display(Name = "Quantidade", Prompt = "")]
        public int Qtd { get; set; }
    }
}
