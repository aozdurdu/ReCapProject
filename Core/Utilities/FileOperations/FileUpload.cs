using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.FileOperations
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
        public string carImages { get; set; }

        public static IDataResult<string> UploadFile(IFormFile file)
        {

            var path = Path.GetTempFileName();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (file.Length > 0)
                using (var stream = new FileStream(path, FileMode.Create))
                    file.CopyTo(stream);

            var result = CreateGuid (file).Data;

            File.Move(path, result);

            return new SuccessDataResult<string>(result);
        }
    }
}
