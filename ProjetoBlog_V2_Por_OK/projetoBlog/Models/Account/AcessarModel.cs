using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoBlog.Models.Account
{
    public class AcessarModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correio")]
        public string Email { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string RetornoUrl { get; set; }
    }
}