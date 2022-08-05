using DTOs.Currency;
using UseCases.Datos_Meli.Services;

namespace UseCases.Datos_Meli
{
    public class SaveCurrencyConversionsInCsvFile : ISaveCurrencyInputPort
    {
        readonly ISaveCurrencyOutputPort OutputPort;
        readonly IMeliRemoteRepository RemoteRepository;
        readonly IFileRepository FileRepository;

        public SaveCurrencyConversionsInCsvFile(ISaveCurrencyOutputPort outputPort, IMeliRemoteRepository remoteRepository, IFileRepository fileRepository)
        {
            OutputPort = outputPort;
            RemoteRepository = remoteRepository;
            FileRepository = fileRepository;
        }

        public async ValueTask Handle(List<CurrencieDto> listaCurrencies)
        {
            List<RatioDto> Ratios = new();
            foreach (var c in listaCurrencies)
            {
                if (c.Todolar != null)
                {
                    var Ratio = new RatioDto(c.Todolar.Ratio) ;
                    Ratios.Add(Ratio);

                }
            }

            await FileRepository.SaveRatioInCsvFile(Ratios);

            await OutputPort.Handle(true);
        }
    }
}
