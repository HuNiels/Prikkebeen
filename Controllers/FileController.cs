using Acupunctuur.data;
using Acupunctuur.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Acupunctuur.Controllers {
    public class FileController : Controller {
        private readonly AcupunctuurContext context;

        public FileController(AcupunctuurContext context) {
            this.context = context;
        }

        /**
         * POST /File/Upload 
         */
        [HttpPost]
        public async Task<int> Upload(IFormFile file) {
            File fileModel = null;
            if (file != null && file.Length > 0) {
                fileModel = new File {
                    FileMimeType = file.ContentType,
                    FileData = new byte[file.Length]
                };
                file.OpenReadStream().Read(fileModel.FileData, 0, (int)file.Length);

                await context.Files.AddAsync(fileModel);
                context.SaveChanges();
            }
            return fileModel == null ? 0 : fileModel.Id;
        }

        /**
         * GET /File/Get
         */
        public FileContentResult Get(int id) {
            File file = context.Files.FirstOrDefault(i => i.Id == id);
            return File(file.FileData, file.FileMimeType);
        }
    }
}
