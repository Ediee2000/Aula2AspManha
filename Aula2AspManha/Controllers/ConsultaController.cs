using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aula2AspManha.Models;
using Aula2AspManha.DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

//Ediee Pinheiro

namespace Aula2AspManha.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly AddressDAO DAOLayer;

        public ConsultaController (AddressDAO _DAOLayer)
        {
            DAOLayer = _DAOLayer;
        }

        public IActionResult Index()
        {

            if (TempData["result_api"] != null)
            {
                
                string result = TempData["result_api"].ToString() ;
                TempData.Remove("result_api");
                Address AddressConsult = JsonConvert.DeserializeObject<Address>(result);
                if (!DAOLayer.SaveAddress(AddressConsult)) {
                    ViewBag.Message = "Cep Invalid";
                  };
            }

            return View(DAOLayer.ListAddress());
        }

        [HttpPost]
        public IActionResult Consulta(string TextCep)
        {
            string url = $"https://viacep.com.br/ws/{TextCep}/json";
            WebClient CepApi = new WebClient();
            if (TextCep != null)
            {
                TempData["result_api"] = CepApi.DownloadString(url);
            }

            return RedirectToAction("Index");
        }
    }
}
