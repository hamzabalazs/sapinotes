using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using SapinotesAPI.Data;
using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _enviroment;

        public DocumentsController(AppDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;
        }

        [HttpPost,Route("upload")]
        public async Task<ActionResult> Upload([FromForm]IFormFile pdfFile)
        {
            

            var rootPath = Path.Combine(_enviroment.ContentRootPath, "Documents");

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            var filePath = Path.Combine(rootPath, pdfFile.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                var document = new Document
                {
                    documentName = pdfFile.FileName,
                    ContentType = pdfFile.ContentType,
                    documentSize = pdfFile.Length
                };

                await pdfFile.CopyToAsync(stream);

                _context.Documents.Add(document);
                await _context.SaveChangesAsync();
                return Ok(document);
            }
            
        }
        
        [HttpPost,Route("download-by-id")]
        public async Task<ActionResult> Download(int id)
        {
            var provider = new FileExtensionContentTypeProvider();

            var document = await _context.Documents.FindAsync(id);

            if (document == null)
                return NotFound();

            var file = Path.Combine(_enviroment.ContentRootPath, "Documents", document.documentName);

            string contentType;
            if(!provider.TryGetContentType(file, out contentType))
            {
                contentType = "application/octet-stream";
            }

            byte[] fileBytes;
            if (System.IO.File.Exists(file))
            {
                fileBytes = System.IO.File.ReadAllBytes(file);
            }
            else
            {
                return NotFound();
            }

            return File(fileBytes, contentType, document.documentName);
        }
        [HttpGet,Route("get-doc")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            try
            {
                var result = await _context.Documents.FirstOrDefaultAsync(d => d.documentID == id);

                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete, Route("delete-doc-by-id")]
        public async Task<ActionResult> DeleteDocument(int id)
        {
            try
            {
                var docToDelete = await _context.Documents.FirstOrDefaultAsync(d => d.documentID == id);

                if (docToDelete != null)
                {
                    _context.Documents.Remove(docToDelete);
                    await _context.SaveChangesAsync();
                    return Ok();

                }

                return NotFound();
                


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting document");
            }

        }

    }
}
