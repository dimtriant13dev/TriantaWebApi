using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriantaWeb.API.Models.Domain;
using TriantaWeb.API.Models.DTO;
using TriantaWeb.API.Repositories;

namespace TriantaWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        //POST: //api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            ValidateFileUpload(imageUploadRequestDto);

            if (ModelState.IsValid)
            {
                //Use repository
                var imageDomainModel = new Image
                {
                    File = imageUploadRequestDto.File,
                    FileExtension = Path.GetExtension(imageUploadRequestDto.FileName),
                    FileSizeInBytes = imageUploadRequestDto.File.Length,
                    FileName = imageUploadRequestDto.FileName,
                    FileDesctiption = imageUploadRequestDto.FileDescription
                };

                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);


            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto imageUploadRequestDto)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if(!allowedExtensions.Contains(Path.GetExtension(imageUploadRequestDto.FileName))) 
            {
                ModelState.AddModelError("File", "Unsupported file extension");
            }
            //If the length is more 10mb
            if(imageUploadRequestDto.File.Length > 10485760)
            {
                ModelState.AddModelError("FileSize", "More than 10Mb , please upload an other file");

            }
        }
    }
}
