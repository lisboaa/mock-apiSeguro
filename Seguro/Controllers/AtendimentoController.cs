using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seguro.Dominio.Entidades;
using System.Net;

namespace Seguro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        [HttpGet]
        [Route("buscarCliente")]
        public Cliente BuscarCliente(String cpf)
        {
            if (cpf.Equals("586.104.160-11"))
            {
                throw new ArgumentException("CPF  invalido!");
            }
            
            //381.696.310-25
            //758.760.920-29
            Cliente cliente = new Cliente();
            cliente.Cpf = cpf;
            cliente.Nome = "Souza";
            cliente.Autonomo = false;
            //cliente.Clt = true;
            //cliente.DataNascimento = "12/10/1998";
            //cliente.Profissao = "Mestre de Obra";
            //cliente.Telefone = "44 9 9229-3323";
            //cliente.Email = "souza@gmail.com";
            //Seguro de vida entre 65 e 75 anos
            //Seguro de saúde apos 65
            //Seguro de automóveis qualquer idade
            cliente.Idade = 66;
            Console.WriteLine(cliente);
            return cliente;
        }

        [HttpPost]
        [Route("salvar")]
        public User Salvar(User user)
        {
            Console.WriteLine(user);
            return user;
        }
    }
}
