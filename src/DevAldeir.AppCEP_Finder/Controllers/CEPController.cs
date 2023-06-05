using DevAldeir.AppCEP_Finder.Models;
using DevAldeir.AppCEP_Finder.Sevice;
using Microsoft.AspNetCore.Mvc;

namespace DevAldeir.AppCEP_Finder.Controllers
{
    public class CEPController : Controller

    {

       private readonly ICEPService _ICEPService;


        public CEPController(ICEPService ICEPService)
        {
            _ICEPService = ICEPService;
        }
        public IActionResult Index()
        {
            return View();
        }


       

        // GET: /ViaCep/GetAddressPartial
        public async Task <IActionResult> GetAddressPartial([FromQuery] string cep)
        {
           
            try
            {
                // Validar se o CEP foi fornecido
                if (string.IsNullOrEmpty(cep))
                {
                    return BadRequest("CEP não fornecido");
                }

                // Chamar o serviço para obter o endereço
                var addressJson = await _ICEPService.GetAddress(cep);

              
                return PartialView("_Addressee", addressJson);
            }
            catch (Exception ex)
            {
       
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }



        }



        // GET: /ViaCep/GetAddressPartial
        public async Task<IActionResult> GetSenderPartial([FromQuery] string cep)
        {

            try
            {
                // Validar se o CEP foi fornecido
                if (string.IsNullOrEmpty(cep))
                {
                    return BadRequest("CEP não fornecido");
                }

          
                var addressJson = await _ICEPService.GetAddress(cep);

                // Retornar a view com os dados do endereço
                  return PartialView("_Sender", addressJson);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }



        }
       

    }
}
