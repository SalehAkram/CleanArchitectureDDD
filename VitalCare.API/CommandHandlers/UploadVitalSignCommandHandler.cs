using MediatR;
using VitalCare.API.Commands;
using VitalCare.API.Dtos;
using VitalCare.API.Services;
using VitalCare.Core.Contracts;

namespace VitalCare.API.CommandHandlers
{
    public class UploadVitalSignCommandHandler : IRequestHandler<UploadVitalSignCommand, UploadVitalSignResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICsvProcessor _csvProcessor;
        public UploadVitalSignCommandHandler(IUnitOfWork unitOfWork, ICsvProcessor csvProcessor)
        {
            _unitOfWork = unitOfWork;
            _csvProcessor = csvProcessor;
        }
        public async Task<UploadVitalSignResponseDto> Handle(UploadVitalSignCommand request, CancellationToken cancellationToken)
        {
            // Dictionary to track processing results
            var (readingsDictionary, failedLineCount) = await _csvProcessor.ParseCsvToDictionaryAsync(request.File, cancellationToken);

            // Fetch valid patients in bulk: 
            var validPatient = await _unitOfWork.PatientRepository.GetPatientsByIdsAsync(readingsDictionary.Keys.ToList(), true);
            var nonExistingPatients = readingsDictionary.Count - validPatient.Count;


            int successfulReadings = 0;
            int failedReadings = failedLineCount + nonExistingPatients;

            // Process and persist the vital signs
            foreach (var patient in validPatient)
            {
                if (readingsDictionary.TryGetValue(patient.Id, out var vitalSignData))
                {
                    try
                    {
                        patient.ProcessVitalSigns(vitalSignData.DateMeasured, vitalSignData.VitalSignType, vitalSignData.Value);
                        successfulReadings++;
                    }
                    catch (Exception)
                    {
                        failedReadings++;
                    }
                }
            }

            // Persist changes to the database
            await _unitOfWork.SaveChangesAsync();

            return new UploadVitalSignResponseDto
            {
                SuccesfullReadings = successfulReadings,
                FailedReadings = failedReadings
            };
        }
    }
}
