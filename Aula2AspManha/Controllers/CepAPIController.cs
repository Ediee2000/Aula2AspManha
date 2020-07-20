using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aula2AspManha.DAL;
using Aula2AspManha.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

//Ediee Pinheiro
namespace Aula2AspManha.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class CepAPIController : ControllerBase
    {
        private readonly AddressDAO DAOLayer;

        public CepAPIController(AddressDAO _DAOLayer)
        {
            DAOLayer = _DAOLayer;
        }

        [HttpGet]
        [Route("ListarEnderecos")]
        public List<Address> ListarEnderecos()
        {
            return DAOLayer.ListAddress();
        }

        [HttpGet("{cep}")]
        [Route("ListarEnderecos/{cep}")]
        public List<Address> ListaEnderecos(string cep)
        {
            return DAOLayer.GetAddress(cep);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult CadastrarEndereco(Address address)
        {
            DAOLayer.SaveAddress(address);
            return Created("", address);
        }

        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult EditAddress(Address address)
        {
            return Created("",DAOLayer.ModifyAddress(address));
        }

        [HttpGet("{id}")]
        [Route("DeletarEndereco/{id}")]
        public IActionResult DeleteAddress(int id)
        {
            if (DAOLayer.DeleteAddress(id))
            {
               return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
