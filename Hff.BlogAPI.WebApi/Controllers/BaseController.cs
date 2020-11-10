using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hff.BlogAPI.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hff.BlogAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public async Task<UploadModel> UploadFile(IFormFile file, string contentType)
        {
            UploadModel uploadModel = new UploadModel();
            if (file != null)
            {
                if (file.ContentType != contentType)
                {
                    uploadModel.ErrorMessage = "Uygunsuz dosya türü";
                    uploadModel.UploadState = Enums.UploadState.Error;
                    return uploadModel;
                }
                else
                {
                    var imageName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var path = Directory.GetCurrentDirectory() + "/wwwroot/img/" + imageName;
                    var stream = new FileStream(path, FileMode.Create);//Path and FileMode
                    await file.CopyToAsync(stream);

                    uploadModel.UploadState = Enums.UploadState.Success;
                    uploadModel.NewName = imageName;
                    return uploadModel;

                }

            }
            uploadModel.UploadState = Enums.UploadState.NotExist;
            uploadModel.ErrorMessage = "Dosya yok";
            return uploadModel;
        }
    }
}
