using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleLoja.Models
{
   

    public class ProdutoModel
    {
        [Key]
        public  int Id { get; set; }  // ADICIONAR O ATRIBUTO [KEY] SE O CAMPO FOR AUTONUMERIC,ASSIM ELE NÃO ENTRA NO INSERT.

        [Display(Name = "Nome", Prompt = "")]
        public string Nome { get; set; }

        [Display(Name = "Preço Custo", Prompt = "")]
        public double Preco_Custo { get; set; }

        [Display(Name = "Preço Sugerido", Prompt = "")]
        public double Preco_Sugerido { get; set; }

        [Display(Name = "Quantidade", Prompt = "")]
        public int Qtd { get; set; }

        [Display(Name = "Categoria", Prompt = "")]
        public int idCategoria { get; set; }

        [Display(Name = "Genero", Prompt = "")]
        public int idGenero { get; set; }

        [Display(Name = "Validade", Prompt = "")]
        public DateTime Validade { get; set; }

    }

    public class ProdutoModelVW:ProdutoModel {
        public string Categoria { get; set; }
        public string Genero { get; set; }        
    }
}
