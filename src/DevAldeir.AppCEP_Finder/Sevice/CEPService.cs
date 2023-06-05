using Microsoft.AspNetCore.Mvc;

namespace DevAldeir.AppCEP_Finder.Sevice
{
    public class CEPService :ICEPService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CEPService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAddress(string cep)
        {
            try
            {
                // Validar se o CEP foi fornecido
                if (string.IsNullOrEmpty(cep))
                {
                    throw new ArgumentException("CEP não fornecido");
                }

                // Remover caracteres não numéricos do CEP
                cep = cep.Replace("-", "").Trim();

                // Verificar se o CEP possui o tamanho correto
                if (cep.Length != 8)
                {
                    throw new ArgumentException("CEP inválido");
                }

                // Criar um cliente HTTP usando o HttpClientFactory
                var httpClient = _httpClientFactory.CreateClient();

                // Fazer uma requisição GET para a API do ViaCep
                var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                // Verificar o status da resposta
                if (response.IsSuccessStatusCode)
                {
                    // Ler o conteúdo da resposta como uma string
                    var content = await response.Content.ReadAsStringAsync();

                    // TODO: Processar o conteúdo da resposta (JSON) de acordo com suas necessidades
                    // Exemplo: desserializar o JSON em um objeto para exibir as informações de endereço

                    // Retornar os dados do endereço como JSON
                    return content;
                }
                else
                {
                    // A requisição falhou, retornar uma mensagem de erro
                    throw new Exception("Não foi possível obter o endereço");
                }
            }
            catch (Exception ex)
            {
                // Tratar qualquer exceção ocorrida durante a requisição
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }



    }
}
