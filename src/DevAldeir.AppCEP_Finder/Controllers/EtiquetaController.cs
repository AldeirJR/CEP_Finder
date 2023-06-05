using DevAldeir.AppCEP_Finder.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevAldeir.AppCEP_Finder.Controllers
{
    public class EtiquetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]

        public IActionResult GerarEtiqueta([FromBody] EtiquetaViewModel etiquetaData)
        {
            if (etiquetaData == null)
            {

                return BadRequest("Dados inválidos");
            }



            // Cria um objeto ViewModel com os dados para serem exibidos na nova view
            var etiquetaViewModel = new EtiquetaViewModel
            {
                Destinatario = etiquetaData.Destinatario.Replace("Logradouro: ", ""),
                Remetente = etiquetaData.Remetente.Replace("Logradouro: ", ""),
                DestinatarioNumero = etiquetaData.DestinatarioNumero,
                DestinatarioComplemento = etiquetaData.DestinatarioComplemento,
                DestinatarioNome = etiquetaData.DestinatarioNome,
                RemetenteNumero = etiquetaData.RemetenteNumero,
                RemetenteComplemento = etiquetaData.RemetenteComplemento,
                RemetenteNome = etiquetaData.RemetenteNome,
                DestinatarioCidade = etiquetaData.RemetenteCidade.Replace("Cidade: ", ""),
                DestinatarioBairro = etiquetaData.DestinatarioBairro.Replace("Bairro: ", ""),
                DestinatarioEstado = etiquetaData.DestinatarioEstado.Replace("Estado: ", ""),
                RemetenteBairro = etiquetaData.RemetenteBairro.Replace("Bairro: ", ""),
                RemetenteCidade = etiquetaData.RemetenteCidade.Replace("Cidade: ", ""),
                RemetenteEstado = etiquetaData.RemetenteEstado.Replace("Estado: ", ""),
                DestinatarioCep = etiquetaData.DestinatarioCep.Replace("CEP: ", ""),
                RemetenteCep = etiquetaData.RemetenteCep.Replace("CEP: ", "")





            };



            return View("Index", etiquetaViewModel);
        }



    }
}
