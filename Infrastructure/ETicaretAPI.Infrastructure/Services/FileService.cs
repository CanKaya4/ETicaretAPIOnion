using ETicaretAPI.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services
{
    public class FileService : IFileService
    {
        readonly IWebHostEnvironment _environment;
        FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await fileStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log
                throw ex;
            }
        }

        public async Task<string> FileRenameAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_environment.WebRootPath, path);

            if (Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            List<bool> results = new();
            foreach (var item in files)
            {
                string fileNewName = await FileRenameAsync(item.FileName);
                bool result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", item);
                datas.Add((fileNewName, $"{uploadPath}\\{fileNewName}"));
                results.Add(result);

            }
            if (results.TrueForAll(r => r.Equals(true)))
                return datas;

            return null;

            //todo Eğer ki yukarıkdai if geçerli değil ise burada dosyaların sunucuda yüklenirken hata alındığına dair uyarıcı bir exception oluşturulmalı ve fırlatılmalı
         
        }

    }
}
