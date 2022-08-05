using CsvHelper;
using DTOs.Currency;
using ExceptionHandler;
using System.Globalization;
using System.Text.Json;
using UseCases.Datos_Meli.Services;

namespace FileRepository
{
    public class FileRepository : IFileRepository
    {
        public async Task SaveJsonFile(List<CurrencieDto> currencies)
        {
            var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", $"currencies.json");
            
            FileInfo ExistingFile = new FileInfo(FilePath);
            if (ExistingFile.Exists)
            {
                ExistingFile.Delete();
            }

            using FileStream CreateStream = File.Create(FilePath);
            try
            {
                await JsonSerializer.SerializeAsync(CreateStream, currencies);
                await CreateStream.DisposeAsync();
            }
            catch (Exception ex)
            {

                throw new BadRequestException($"No se pudo guardar el archivo json. {ex.Message}");
            }
   
        }

        public Task SaveRatioInCsvFile(List<RatioDto> ratios)
        {
            var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", $"ratios.csv");

            FileInfo ExistingFile = new FileInfo(FilePath);
            if (ExistingFile.Exists)
            {
                ExistingFile.Delete();
            }

            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ratios);
            }
            return Task.CompletedTask;
        }
    }
}