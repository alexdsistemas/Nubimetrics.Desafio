using DTOs.Currency;
using Services;
using UseCases.Datos_Meli.Services;

namespace ChallengeNubimetricsWeb
{
    public class HostedService : IHostedService, IDisposable
    {
        private Timer Timer = null!;
        readonly ISaveCurrenciesInputPort SaveCurrenciesInputPort;
        readonly ISaveCurrenciesOutputPort SaveCurrenciesOutputPort;
        readonly ISaveCurrencyInputPort SaveCurrencyInputPort;

        public HostedService(ISaveCurrenciesInputPort saveCurrenciesInputPort, ISaveCurrenciesOutputPort saveCurrenciesOutputPort, ISaveCurrencyInputPort saveCurrencyInputPort)
        {
            SaveCurrenciesInputPort = saveCurrenciesInputPort;
            SaveCurrenciesOutputPort = saveCurrenciesOutputPort;
            SaveCurrencyInputPort = saveCurrencyInputPort;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Timer = new Timer(DoWork, null, TimeSpan.FromMinutes(5), TimeSpan.FromHours(24));
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            await SaveCurrenciesInputPort.Handle();

            var ListCurrencies = ((IPresenter<List<CurrencieDto>>)SaveCurrenciesOutputPort).Content;

            await SaveCurrencyInputPort.Handle(ListCurrencies);

        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            Timer?.Change(Timeout.Infinite, Timeout.Infinite);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Timer?.Dispose();
        }
    }
}
