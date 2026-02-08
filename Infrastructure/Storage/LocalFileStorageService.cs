using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storage
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly string _rootPath;

        public LocalFileStorageService()
        {
            _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        }

        public async Task<string> SaveAsync(IFormFile file, string folder)
        {
            if (!Directory.Exists(_rootPath))
                Directory.CreateDirectory(_rootPath);

            var folderPath = Path.Combine(_rootPath, folder);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(folderPath, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/Uploads/{folder}/{fileName}";
        }
    }
}
