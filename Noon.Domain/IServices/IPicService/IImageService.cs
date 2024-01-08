using Microsoft.AspNetCore.Http;
using Noon.Domain.Entities.ImageResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.IServices.IPicService
{
    public interface IImageService
    {
        Task<ImageRecord> SaveImage(IFormFileCollection  fileCollection, Guid productId, string objectName);
        List<string> GetImage(string hostUrl,Guid  productId, string objectName);
        void DeleteImage(Guid productId, string objectName);
    }
}
