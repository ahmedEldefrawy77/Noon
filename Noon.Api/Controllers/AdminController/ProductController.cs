using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noon.Application.DTOs.Record.Product;
using Noon.Application.Features.ProductFeatures.Request.Commands;
using Noon.Application.Features.ProductFeatures.Request.Queries;
using Noon.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Noon.Api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _environment;
  
        public ProductController(IMediator mediator, IWebHostEnvironment environment)
        {
            _mediator = mediator;
            _environment = environment;
            
        }
       
       
        //[HttpGet("{id:Guid}/GetImage")]
        //public async Task<IActionResult> GetImage([FromRoute]Guid id)
        //{
        //    BaseCommonResponse rs = new BaseCommonResponse();
        //    List<string> imageURL = new List<string>();
        //    string hostURL = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        //    try
        //    {
        //        string filePath = GetFilePath(id);

        //        if (System.IO.Directory.Exists(filePath))
        //        {
        //            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
        //            FileInfo[] files = directoryInfo.GetFiles();
        //            foreach (FileInfo file in files)
        //            {
        //                string filename = file.Name;
        //                string imagepath = filePath + "\\" + filename; //that is the property that should be added to the product to have the actual path of pics
        //                if (System.IO.File.Exists(imagepath))
        //                {
        //                    imageURL.Add(hostURL + "/ImageUpload/Product/" + id + "/" + filename);
        //                }
        //            }
        //        }
        //        rs.Response = imageURL.ToArray();
        //        List<byte[]> imageBytesList = new List<byte[]>();
        //        foreach (string localPath in imageURL)
        //        {
        //            // Now, read the image bytes from the local path, not the URL
        //            //string localFilePath = GetLocalFilePath(localPat); 
        //            byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);
        //            imageBytesList.Add(imageBytes);
        //        }

        //        return Ok(imageBytesList);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
            
        //}
        //[HttpGet("download")]
        //public async Task<IActionResult> download(Guid productId)
        //{
        //    try
        //    {
        //        string filePath = GetFilePath(productId);
        //        string imagePath = filePath + "\\" + productId;
        //        if (System.IO.Directory.Exists(filePath))
        //        {
        //            MemoryStream stream = new MemoryStream();
        //            using (FileStream file = new FileStream(imagePath, FileMode.Open))
        //            {
        //                await file.CopyToAsync(stream);
        //            }
        //            stream.Position = 0;
        //            return File(stream, "image/png" + productId + ".png");
        //        }
        //        else { return NotFound(); }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

       
        [HttpPost]
        public async Task<IActionResult> CreatePoduct([FromForm] CreateProductRecord uRequest)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            return Ok(response = await _mediator.Send(new CreateProductRequest { Productrecord = uRequest }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategory(string Name )
        {
            BaseCommonResponse response = await _mediator.Send(new GetAllProductsForCategoryRequest { CategoryName = Name  });
            return Ok(response);
        }

        [HttpGet("Brand")]
        public async Task<IActionResult> GetAllProductBrand(string Name)
        {
            BaseCommonResponse response = await _mediator.Send(new GetAllProductsWithBrandNameRequest { Name = Name });
            return Ok(response);
        }

        [HttpGet("SpecifiedCategory")]
        public async Task<IActionResult> GetAllProductSpecifiedCategory(string Name)
        {
            BaseCommonResponse response = await _mediator.Send(new GetAllProductWithSpecifiedCategoryNameRequest {Name = Name});
            return Ok(response);
        }

        [HttpGet("PriceRange")]
        public async Task<IActionResult> GetProductByPriceRange(ProductPricingRecord urequest)
        {
            BaseCommonResponse response = await _mediator.Send(new GetProductsByPriceRangeRequest { request = urequest});
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            BaseCommonResponse response = await _mediator.Send(new  DeleteProductRequest { id = id });
            return Ok(response);
        }

    }
}
