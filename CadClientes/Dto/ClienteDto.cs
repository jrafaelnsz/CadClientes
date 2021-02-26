using CadClientes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CadClientes.Dto
{
    public class ClienteDto
    {
        public ClienteDto()
        {
            dicGenero = new Dictionary<string, string>();
            dicGenero.Add("M", "Masculino");
            dicGenero.Add("F", "Feminino");
            dicGenero.Add("I", "Indefinido");
        }

        [Display(Name = "ID")]
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "Data de Nascimento")]
        public string DtNascimento { get; set; }
        public string Sexo { get; set; }

        Dictionary<string, string> dicGenero;        

        public static List<ClienteDto> ConverterLista(List<Cliente> listaClientes)
        {
            var listaClienteDto = new List<ClienteDto>();
            foreach (var cliente in listaClientes)
            {
                listaClienteDto.Add(ConverterCliente(cliente));
            }
            return listaClienteDto;
        }

        public static ClienteDto ConverterCliente(Cliente cliente)
        {           
            var clienteDto = new ClienteDto();
            clienteDto.ClienteId = cliente.ClienteId;
            clienteDto.Nome = cliente.Nome;
            clienteDto.Cpf = cliente.Cpf;
            clienteDto.DtNascimento = cliente.DtNascimento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            clienteDto.Sexo = clienteDto.dicGenero[cliente.Sexo];
            return clienteDto;
        }
    }
}