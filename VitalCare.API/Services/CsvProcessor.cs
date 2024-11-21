using VitalCare.API.Dtos;

namespace VitalCare.API.Services
{
    public class CsvProcessor: ICsvProcessor
    {
        public async Task<(Dictionary<int, VitalSignDto> readingsDictionary, int failedCount)> ParseCsvToDictionaryAsync(IFormFile file, CancellationToken cancellationToken)
        {
           throw new NotImplementedException();
        }
    }
}
