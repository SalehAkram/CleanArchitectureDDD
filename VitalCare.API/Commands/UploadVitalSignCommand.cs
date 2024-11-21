using MediatR;
using VitalCare.API.Dtos;

namespace VitalCare.API.Commands
{
    public class UploadVitalSignCommand : IRequest<UploadVitalSignResponseDto>
    {
        public IFormFile File { get; }
        public UploadVitalSignCommand(IFormFile file)
        {
            File = file;
        }
    }
}
