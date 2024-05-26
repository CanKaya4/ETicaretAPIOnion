
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
    public class FileService 
    {
       
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
        
    }
}
