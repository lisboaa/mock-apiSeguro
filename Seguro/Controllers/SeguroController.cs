using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seguro.Dominio.Entidades;
using System.Net;

namespace Seguro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : ControllerBase
    {
        [HttpGet]
        [Route("buscarSeguro")]
        public List<Seguro2> BuscarSeguro()
        {
            List<Seguro2> seguro2 = new();
            seguro2.Add(new Seguro2 { Nome = "Seguro de vida", Valor = 50000});
            seguro2.Add(new Seguro2 { Nome = "Seguro de saúde", Valor = 30000 });
            seguro2.Add(new Seguro2 { Nome = "Seguro de saúde", Valor = 90000 });
            return seguro2;
        }
    }
}
