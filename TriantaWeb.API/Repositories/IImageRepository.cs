using TriantaWeb.API.Models.Domain;

namespace TriantaWeb.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image>Upload(Image image);
    }
}
