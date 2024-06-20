using TriantaWeb.API.Data;
using TriantaWeb.API.Models.Domain;

namespace TriantaWeb.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly TriantaDbContext triantaDbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment , IHttpContextAccessor httpContextAccessor , TriantaDbContext triantaDbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.triantaDbContext = triantaDbContext;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath,"Images",image.FileName,image.FileExtension);

            //Upload Image To local Path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}";

            image.FilePath = urlFilePath;

            //add image to Images Tatble

            await triantaDbContext.Images.AddAsync(image);
            await triantaDbContext.SaveChangesAsync();

            return image;
            
        }
    }
}
