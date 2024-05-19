using ETicaretAPI.Application.Services;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.Operations;
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
        readonly private IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log
                throw ex;
            }
        }

        private async Task<string> FileRenameAsync(string filePath, string fileName, bool first = true)
        {
            //string newFileName = await Task.Run<string>(async () =>
            //       {
            //           string extension = Path.GetExtension(fileName);

            //           string newFileName = string.Empty;
            //           if (first)
            //           {
            //               string oldName = Path.GetFileNameWithoutExtension(fileName);
            //               newFileName = $"{NameOperation.CharecterRegulatory(oldName)}{extension}";
            //           }
            //           else
            //           {
            //               newFileName = fileName;
            //               int indexNo1 = newFileName.IndexOf("-");
            //               if (indexNo1 == -1)
            //               {
            //                   newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
            //               }
            //               else
            //               {
            //                   int lastIndex = 0;
            //                   while (true)
            //                   {
            //                       lastIndex = indexNo1;
            //                       indexNo1 = newFileName.IndexOf("-", indexNo1 + 1);
            //                       if(indexNo1 == -1)
            //                       {
            //                           indexNo1 = lastIndex;
            //                           break;
            //                       }
            //                   }
            //                   int indexNo2 = newFileName.IndexOf(".");
            //                   string fileNo = newFileName.Substring(indexNo1 + 1, - indexNo2 - indexNo1 -1);

            //                   if(int.TryParse(fileNo,out int _fileNo))
            //                   {
            //                       _fileNo++;
            //                       newFileName = newFileName.Remove(indexNo1 + 1, indexNo2 - indexNo1 - 1).Insert(indexNo1, _fileNo.ToString());
            //                   }
            //                   else
            //                   {
            //                       newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
            //                   }





            //               }
            //           }
            //           if (File.Exists($"{filePath}\\{newFileName}"))
            //               return await FileRenameAsync(filePath, newFileName, false);
            //           else
            //               return newFileName;
            //       });

            //return newFileName;
            return await Task.Run<string>(() =>
            {
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                string extension = Path.GetExtension(fileName);
                string newFileName = $"{NameOperation.CharecterRegulatory(oldName)}{extension}";

                bool fileExists = false;
                int fileIndex = 0;
                do
                {
                    if (File.Exists($"{filePath}\\{newFileName}"))
                    {
                        fileExists = true;
                        fileIndex++;
                        newFileName = $"{NameOperation.CharecterRegulatory(oldName + "-" + fileIndex)}{extension}";
                    }
                    else
                    {
                        fileExists = false;
                    }
                } while (fileExists);



                return newFileName;
            });

        
        }
        
        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_environment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            List<bool> results = new();
            foreach (var item in files)
            {
                string fileNewName = await FileRenameAsync(uploadPath, item.FileName);
                bool result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", item);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
                results.Add(result);

            }
            if (results.TrueForAll(r => r.Equals(true)))
                return datas;

            return null;

            //todo Eğer ki yukarıkdai if geçerli değil ise burada dosyaların sunucuda yüklenirken hata alındığına dair uyarıcı bir exception oluşturulmalı ve fırlatılmalı

        }

    }
}
