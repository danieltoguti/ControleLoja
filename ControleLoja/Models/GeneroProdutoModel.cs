﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleLoja.Models
{
    public class GeneroProdutoModel
    {
        public int Id { get; set; }


        [Display(Name = "Nome", Prompt = "")]
        public string Genero { get; set; }
    }

}
