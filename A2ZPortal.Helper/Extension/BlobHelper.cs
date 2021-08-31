using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace A2ZPortal.Helper.Extension
{
    public static class BlobHelper
    {
        public static async Task<List<string>> UploadImageOnFolder(List<IFormFile> imageFiles,
            IHostingEnvironment _hostingEnvironment)
        {
            var imageStoragePaths = new List<string>();
            foreach (var file in imageFiles)
                try
                {
                    switch (file)
                    {
                        case { Length: > 0 }:
                            {
                                var upload = Path.Combine(_hostingEnvironment.WebRootPath, "PropertyImage//");
                                await using (var fs = new FileStream(Path.Combine(upload, file.FileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fs);
                                }

                                imageStoragePaths.Add("/PropertyImage/" + file.FileName);
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }

            return imageStoragePaths;
        }
    }
}