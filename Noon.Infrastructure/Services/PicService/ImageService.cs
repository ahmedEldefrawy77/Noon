using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Noon.Domain.Entities.ImageResult;
using Noon.Domain.IServices.IPicService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Services.PicService
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _accessor;
        int passCount; int passFail;
        public ImageService(IWebHostEnvironment environment,IHttpContextAccessor accessor)
        {
            _environment = environment;
            _accessor = accessor;
        }
        public async Task<List<string>> GetImage(string hostUrl,Guid productId)
        {
            List<string> imageURLs = new List<string>();
           
            try
            {
                string filePath = GetFilePath(productId);

                if (System.IO.Directory.Exists(filePath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
                    FileInfo[] files = directoryInfo.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        string filename = file.Name;
                        string imagepath = filePath + "\\" + filename; //that is the property that should be added to the product to have the actual path of the pics
                        if (System.IO.File.Exists(imagepath))
                        {
                            imageURLs.Add(hostUrl + "/ImageUpload/Product/" + productId + "/" + filename);
                        }
                    }
                }
                foreach (string localPath in imageURLs)
                {
                    imageURLs.Add(localPath);
                }

             
            }
            catch(Exception)
            {
                throw;
            }
           
            return imageURLs;
        }

        public async Task<ImageRecord> SaveImage(IFormFileCollection fileCollection, Guid productId)
        {
            ImageRecord imageResult = new ImageRecord();
            List<string> imagePaths = new List<string>();
            try
            {
                string FilePath = GetFilePath(productId);
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string apiUrl = GetRootUrl();
                foreach (var file in fileCollection)
                {  
                    string staticFileToBeRetrievedFromDb = apiUrl + "/ImageUpload/Product/" + productId + "/" + productId + file.FileName;

                    string imagePathTobeSaved = FilePath + "\\" + productId+ file.FileName;

                    if (System.IO.File.Exists(imagePathTobeSaved))
                    {
                        System.IO.File.Delete(imagePathTobeSaved);
                    }
                    using (FileStream stream = System.IO.File.Create(imagePathTobeSaved))
                    {
                        passCount++;

                        await file.CopyToAsync(stream);


                        imagePaths.Add(staticFileToBeRetrievedFromDb);

                    }
                }
               
            }
            catch (Exception)
            {
                passFail++;
               
            }

            imageResult.imagePaths = imagePaths;
            imageResult.passFail = passFail;
            imageResult.passCount = passCount;

            return imageResult;
        }
        private string GetFilePath(Guid productId)
        {
            return _environment.WebRootPath + "\\ImageUpload\\Product\\" + productId;
        }
        public string GetRootUrl()
        {
            var request = _accessor.HttpContext?.Request;
            var baseUrl = $"{request?.Scheme}://{request?.Host.Value}";

            return baseUrl;
        }
    }
}
