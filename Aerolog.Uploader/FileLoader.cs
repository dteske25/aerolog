using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticFiles;

namespace Aerolog.Uploader.SeriesLoader
{
    public static class FileLoader
    {
        public static async Task<Core.File> GetLocalFile(string path)
        {
            var fi = new FileInfo(path);
            var contentTypeProvider = new FileExtensionContentTypeProvider();
            Core.File file = null;
            if (fi != null)
            {
                using var stream = new MemoryStream();
                await fi.OpenRead().CopyToAsync(stream);

                contentTypeProvider.TryGetContentType($"{fi.Name}{fi.Extension}", out var contentType);
                file = new Core.File
                {
                    FileName = fi.Name,
                    ContentType = contentType,
                    FileContent = stream.ToArray(),
                };
            }
            return file;

        }
    }
}
