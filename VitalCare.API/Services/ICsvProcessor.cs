using VitalCare.API.Dtos;

namespace VitalCare.API.Services
{
    public interface ICsvProcessor
    {
        Task<(Dictionary<int, VitalSignDto> readingsDictionary, int failedCount)> ParseCsvToDictionaryAsync(IFormFile file, CancellationToken cancellationToken);

    }
}
