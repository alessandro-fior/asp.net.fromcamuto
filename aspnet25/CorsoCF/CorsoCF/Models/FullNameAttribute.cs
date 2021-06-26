using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CorsoCF.Models
{
    public class FullNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string NomeIntero = value.ToString();
            int NumeroParole = NomeIntero.Split(' ').Count();
            return (NumeroParole >= 1 && NumeroParole < 3);
        }

    }
}