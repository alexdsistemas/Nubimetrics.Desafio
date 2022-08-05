using UseCases.Datos_Meli.Services;

namespace UseCases.Datos_Meli
{
    public class SaveCurrenciesInJsonFile : ISaveCurrenciesInputPort
    {
        readonly IFileRepository FileRepository;
        readonly IMeliRemoteRepository RemoteRepository;
        readonly ISaveCurrenciesOutputPort OutputPort;

        public SaveCurrenciesInJsonFile(IFileRepository fileRepository, IMeliRemoteRepository remoteRepository, ISaveCurrenciesOutputPort outputPort)
        {
            FileRepository = fileRepository;
            RemoteRepository = remoteRepository;
            OutputPort = outputPort;
        }

        public async ValueTask Handle()
        {
            var ListaCurrencies = await RemoteRepository.GetCurrencies();
            if (ListaCurrencies.Count > 0)
            {
                foreach (var c in ListaCurrencies)
                {
                    if (c.Id.Contains("VES") || c.Id.Contains("VEF"))
                    {
                        continue;
                    }
                    
                        var Result = await RemoteRepository.ConversionToUSD(c.Id);
                        if (Result != null)
                        {
                            c.Todolar = Result;
                        }
                    
                    
                }
                 await FileRepository.SaveJsonFile(ListaCurrencies);
            }

            await OutputPort.Handle(ListaCurrencies);
        }
    }
}
