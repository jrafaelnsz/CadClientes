//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CadClientes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cliente
    {
        [Display(Name ="ID")]
        public int ClienteId { get; set; }
        
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [Display(Name = "Data de Nascimento")]
        public System.DateTime DtNascimento { get; set; }
        public string Sexo { get; set; }
    }
}