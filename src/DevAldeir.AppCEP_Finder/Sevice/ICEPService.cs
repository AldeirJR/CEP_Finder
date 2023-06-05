namespace DevAldeir.AppCEP_Finder.Sevice
{
    public interface ICEPService
    {
        Task<string> GetAddress(string cep);

    }
}