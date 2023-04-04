using SandeepThippareddy.Models;

namespace SandeepThippareddy.Interfaces
{
    public interface IDownloaderService
    {
        bool SaveDownloaderData(DownloaderModel downloaderModel);
    }
}
